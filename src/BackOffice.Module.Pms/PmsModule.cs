using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Modules;
using Poseidon.BackOffice.Module.Pms.ViewModels;
using Poseidon.BackOffice.Module.Pms.Views;

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

            _container.RegisterType<object, CurrenciesView>(View.CurrenciesView);

            _container.RegisterType<CurrenciesViewModel>();
        }
    }
}