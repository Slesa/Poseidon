using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Core;
using Poseidon.BackOffice.Module.Ics;
using Poseidon.BackOffice.Module.Pms;
using Poseidon.BackOffice.Module.Ums;
using Poseidon.BackOffice.ViewModels;
using Poseidon.BackOffice.Views;
using Poseidon.Common;
using Poseidon.Common.Persistence;
using Unity.AutoRegistration;

namespace Poseidon.BackOffice
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            var logFile = new FileInfo("Poseidon.BackOffice.log4net.config");
            log4net.Config.XmlConfigurator.Configure(logFile);

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
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
            return new ModuleCatalog(GetModules());
        }

        IEnumerable<ModuleInfo> GetModules()
        {
            var icsModule = typeof(IcsModule);
            yield return new ModuleInfo
                {
                    ModuleName = icsModule.Name,
                    ModuleType = icsModule.AssemblyQualifiedName
                };
            var umsModule = typeof(UmsModule);
            yield return new ModuleInfo
                {
                    ModuleName = umsModule.Name,
                    ModuleType = umsModule.AssemblyQualifiedName
                };
            var pmsModule = typeof(PmsModule);
            yield return new ModuleInfo
                {
                    ModuleName = pmsModule.Name,
                    ModuleType = pmsModule.AssemblyQualifiedName
                };
            var coreModule = typeof(CoreModule);
            yield return new ModuleInfo
                {
                    ModuleName = coreModule.Name,
                    ModuleType = coreModule.AssemblyQualifiedName
                };
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
            /*
            */
            var dbConnection = ConfigurationManager.AppSettings["DbConnection"];
            //Container.RegisterType<IPersistenceConfiguration, SqlServerPersistenceConfiguration>(new ContainerControlledLifetimeManager(), new InjectionConstructor(dbConnection));
            Container.RegisterType<IPersistenceConfiguration, SqlServerPersistenceConfiguration>(new InjectionConstructor(dbConnection));

            Container.ConfigureAutoRegistration()
                .LoadAssembliesFrom(GetRegistrationAssemblies())
                //.LoadAssemblyFrom("Poseidon.Domain.Ics.Hibernate.dll")
                //.ExcludeAssemblies(a=>!a.GetName().FullName.Contains("Poseidon"))
                //.ExcludeAssemblies(a => a.GetName().FullName.Contains("Specs"))
                //.Include(type => type.IsGenericTypeDefinition .<ClassMap<>>, Then.Register().UsingPerCallMode())
                .Include(If.Implements<IMappingContributor>, Then.Register().WithTypeName())
                .Include(If.Implements<IHibernateInitializationAware>, Then.Register().WithTypeName())
                //.Exclude(t => t.Name.Equals("FluentMappingFromAssembly"))
                .ApplyAutoRegistration();

            var mappingContributors = Container.ResolveAll<IMappingContributor>();
            //System.Diagnostics.Debug.Assert(mappingContributors.Count()>3);
            /*
            yield return AllTypes
                .FromAssemblyContaining(typeof(IMappingContributor))
                .BasedOn(typeof(IMappingContributor))
                .WithService.Base();*/
            RegisterTypeIfMissing(typeof(IHibernatePersistenceModel), typeof(HibernatePersistenceModel), true);
            /*
            yield return AllTypes
                .FromAssemblyContaining(typeof(INHibernateInitializationAware))
                .BasedOn(typeof(INHibernateInitializationAware))
                .WithService.Base();*/
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