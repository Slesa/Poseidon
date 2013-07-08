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
            _container.RegisterType<PmsOfficeModule>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IOfficeModule,CurrencyModule>(CurrencyModule.Name);
            _container.RegisterType<IOfficeModule,DiscountModule>(DiscountModule.Name);
            _container.RegisterType<IOfficeModule,SalesFamilyModule>(SalesFamilyModule.Name);
            _container.RegisterType<IOfficeModule,SalesItemModule>(SalesItemModule.Name);
        }
    }
}