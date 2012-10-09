using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.Ums.OfficeModule.Views;

namespace Poseidon.Ums.OfficeModule
{
    public class UmsOfficeModule : IModule
    {
        readonly IUnityContainer _container;
        readonly IRegionManager _regionManager;

        public UmsOfficeModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ListRegion", () => _container.Resolve<UsersListView>());
            _regionManager.RegisterViewWithRegion("EditRegion", () => _container.Resolve<UserEditView>());
        }
    }
}
