﻿using System.IO;
using System.Windows;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Poseidon.BackOffice.Core;
using Poseidon.BackOffice.ViewModels;
using Poseidon.BackOffice.Views;
using Poseidon.Common;

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
            RegisterShellObjects();
            RegisterViews();
        }

        protected override void ConfigureModuleCatalog()
        {
            var coreModule = typeof(CoreModule);
            ModuleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = coreModule.Name,
                ModuleType = coreModule.AssemblyQualifiedName
            });

        }

        void RegisterShellObjects()
        {
            RegisterTypeIfMissing(typeof(ILoggerFacade), typeof(Log4NetLogger), true);
            RegisterTypeIfMissing(typeof(IRegionManager), typeof(IRegionManager), true);
        }

        void RegisterViews()
        {
            RegisterTypeIfMissing(typeof(ShellViewModel), typeof(ShellViewModel), true);
        }
    }
}