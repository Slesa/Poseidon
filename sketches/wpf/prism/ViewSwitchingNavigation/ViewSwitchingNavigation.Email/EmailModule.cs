using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ViewSwitchingNavigation.Email.ViewModels;
using ViewSwitchingNavigation.Email.Views;
using ViewSwitchingNavigation.Infrastructure;

namespace ViewSwitchingNavigation.Email
{
    public class EmailModule : IModule
    {
        readonly IUnityContainer _container;
        readonly IRegionManager _regionManager;

        public EmailModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {

            _container.RegisterType<ComposeEmailViewModel>();
            _container.RegisterType<EmailNavigationItemViewModel>();
            _container.RegisterType<EmailViewModel>();
            _container.RegisterType<InboxViewModel>();

            _container.RegisterType<object, ComposeEmailView>("ComposeEmailView");
            _container.RegisterType<object, EmailView>("EmailView");
            _container.RegisterType<object, InboxView>("InboxView");

            _regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(EmailNavigationItemView));
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, EmailNavigationItemViewModel.EmailsViewUri);
        }
    }
}