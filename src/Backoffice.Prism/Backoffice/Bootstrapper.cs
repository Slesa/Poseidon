using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using Backoffice;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Poseidon.Backoffice.Views;
using Poseidon.Ums.OfficeModule;

namespace Poseidon.Backoffice
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

            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            
            RegisterShellObjects();
        }
        
        void RegisterShellObjects()
        {
            //RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);

            RegisterTypeIfMissing(typeof(Shell), typeof(Shell), true);
            RegisterTypeIfMissing(typeof(ILoggerFacade), typeof(Log4NetLogger), true);
            
        } 
        
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog {ModulePath = @".\Modules"};
        }
        
        /*
        protected override void ConfigureModuleCatalog()
        {
            System.Type officeModule = typeof (UmsOfficeModule);
            ModuleCatalog.AddModule(new ModuleInfo(officeModule.Name, officeModule.AssemblyQualifiedName));
        }*/
    }
}