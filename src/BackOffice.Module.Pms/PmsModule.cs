using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Modules;

namespace Poseidon.BackOffice.Module.Pms
{
    public class PmsModule : IModule
    {
        readonly IUnityContainer _container;

        public PmsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            var pmsModule = new PmsOfficeModule();
            _container.RegisterType<IOfficeModule,CurrencyModule>(CurrencyModule.Name, new InjectionConstructor(pmsModule));
            _container.RegisterType<IOfficeModule,DiscountModule>(DiscountModule.Name, new InjectionConstructor(pmsModule));
            _container.RegisterType<IOfficeModule,SalesFamilyModule>(SalesFamilyModule.Name, new InjectionConstructor(pmsModule));
            _container.RegisterType<IOfficeModule,SalesItemModule>(SalesItemModule.Name, new InjectionConstructor(pmsModule));
        }
    }
}