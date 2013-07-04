using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.ViewModels;
using Poseidon.BackOffice.Core.Views;

namespace Poseidon.BackOffice.Core
{
    public class CoreModule : IModule
    {
        readonly IUnityContainer _container;
        readonly IRegionManager _regionManager;

        public CoreModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(Regions.TagStatusBarRegion, typeof(StatusbarView));
            _regionManager.RegisterViewWithRegion(Regions.TagNavigationRegion, typeof(NavigationView));
            _regionManager.RegisterViewWithRegion(Regions.TagModulesRegion, typeof(ModulesView));

            _container.RegisterType<ModulesViewModel>();
        }
    }
}