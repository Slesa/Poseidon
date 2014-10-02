using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.ViewModels;
using Poseidon.BackOffice.Views;
using Poseidon.Common.Persistence;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Common.Wpf;
using Unity.AutoRegistration;

namespace Poseidon.BackOffice
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<ShellView>();
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();

            var logFile = new FileInfo("Poseidon.BackOffice.log4net.config");
            log4net.Config.XmlConfigurator.Configure(logFile);

            var eventAggregator = Container.Resolve<IEventAggregator>();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
            eventAggregator.GetEvent<ApplicationReadyEvent>().Publish(0);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterPersistence();
            RegisterShellObjects();
            RegisterViews();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ModuleCatalog(ModuleLoader.CollectModules());
        }

        void RegisterShellObjects()
        {
            RegisterTypeIfMissing(typeof(ILoggerFacade), typeof(Log4NetLogger), true);
            RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
        }

        void RegisterViews()
        {
            RegisterTypeIfMissing(typeof(ShellViewModel), typeof(ShellViewModel), true);
        }

        void RegisterPersistence()
        {
            var dbConnection = ConfigurationManager.AppSettings["DbConnection"];
            //Container.RegisterType<IPersistenceConfiguration, SqlServerPersistenceConfiguration>(new ContainerControlledLifetimeManager(), new InjectionConstructor(dbConnection));
            Container.RegisterType<IPersistenceConfiguration, SqlServerPersistenceConfiguration>(new InjectionConstructor(dbConnection));

            Container.ConfigureAutoRegistration()
                .LoadAssemblyFrom(GetRegistrationAssemblies())
                //.ExcludeAssemblies(a=>!a.GetName().FullName.Contains("Poseidon"))
                .ExcludeAssemblies(a => a.GetName().FullName.Contains("Specs"))
                //.Include(type => type.IsGenericTypeDefinition .<ClassMap<>>, Then.Register().UsingPerCallMode())
                .Include(If.Implements<IMappingContributor>, Then.Register().WithTypeName())
                .Include(If.Implements<IHibernateInitializationAware>, Then.Register().WithTypeName())
                //.Include(If.Implements<IHibernatePersistenceModel>, Then.Register().WithTypeName())
                .ApplyAutoRegistration();

            RegisterTypeIfMissing(typeof(IHibernatePersistenceModel), typeof(HibernatePersistenceModel), true);
            RegisterTypeIfMissing(typeof(IHibernateSessionFactory), typeof(HibernateSessionFactory), true);
            RegisterTypeIfMissing(typeof(IDbConversation), typeof(DbConversation), true);
        }

        IEnumerable<string> GetRegistrationAssemblies()
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var dllPath in Directory.GetFiles(directoryPath, "Poseidon.*.dll"))
            {
                Assembly assembly;
                try
                {
                    assembly = Assembly.LoadFrom(dllPath);
                    //AppDomain.CurrentDomain.Ass
                    //if (AppDomain.CurrentDomain.GetAssemblies().Contains(dllPath)) continue;
                }
                catch (BadImageFormatException ex)
                {
                    System.Diagnostics.Trace.TraceError(ex.ToString());
                    continue;
                }
                catch (FileNotFoundException ex)
                {
                    System.Diagnostics.Trace.TraceError(ex.ToString());
                    continue;
                }
                yield return assembly.CodeBase;
            }
        }
    }
}