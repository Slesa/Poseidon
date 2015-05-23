using System.Collections.Generic;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using ViewSwitchingNavigation.Email;
using ViewSwitchingNavigation.Email.Model;
using ViewSwitchingNavigation.Infrastructure;
using ViewSwitchingNavigation.ViewModels;

namespace ViewSwitchingNavigation
{
    // http://blogs.msdn.com/b/kashiffl/archive/2011/03/10/prism-4-region-navigation-with-silverlight-frame-navigation-and-unity.aspx
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
            RegisterShellObjects();
            RegisterViews();
        }

        void RegisterShellObjects()
        {
            //RegisterTypeIfMissing(typeof(IUnity), typeof(RegionManager), true);
            RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
            RegisterTypeIfMissing(typeof(IPopupDialogWindow), typeof(ChildWindow), false);
            Container.RegisterInstance<IEmailService>(new EmailService());
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
