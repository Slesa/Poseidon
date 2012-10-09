using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.Pms.OfficeModule.Views;

namespace Poseidon.Pms.OfficeModule
{
    public class PmsOfficeModule : IModule
    {
        readonly IUnityContainer _container;
        readonly IRegionManager _regionManager;

        public PmsOfficeModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ListRegion", () => _container.Resolve<PayformsListView>());
            _regionManager.RegisterViewWithRegion("EditRegion", () => _container.Resolve<PayformEditView>());
        }
    }
}
