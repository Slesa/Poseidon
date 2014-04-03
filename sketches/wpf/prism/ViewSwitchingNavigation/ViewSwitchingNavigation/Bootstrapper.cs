using System.Collections.Generic;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using ViewSwitchingNavigation.Email;
using ViewSwitchingNavigation.ViewModels;

namespace ViewSwitchingNavigation
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

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterViews();
        }

        void RegisterViews()
        {
            RegisterTypeIfMissing(typeof(ShellViewModel), typeof(ShellViewModel), true);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ModuleCatalog(GetModules());
        }

        IEnumerable<ModuleInfo> GetModules()
        {
            var mailModule = typeof(EmailModule);
            yield return new ModuleInfo
                {
                    ModuleName = mailModule.Name,
                    ModuleType = mailModule.AssemblyQualifiedName,
                };
        }
    }
}