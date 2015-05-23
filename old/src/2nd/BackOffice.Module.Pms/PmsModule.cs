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
            _container.RegisterType<IOfficeModule,PayformModule>(PayformModule.Name);
            _container.RegisterType<IOfficeModule,SalesFamilyModule>(SalesFamilyModule.Name);
            _container.RegisterType<IOfficeModule,SalesFamilyGroupModule>(SalesFamilyGroupModule.Name);
            _container.RegisterType<IOfficeModule,SalesItemModule>(SalesItemModule.Name);
            _container.RegisterType<IOfficeModule,WaiterModule>(WaiterModule.Name);
            _container.RegisterType<IOfficeModule,WaiterTeamModule>(WaiterTeamModule.Name);

            _container.RegisterType<object, CurrenciesView>(View.CurrenciesView);
            _container.RegisterType<object, DiscountsView>(View.DiscountsView);
            _container.RegisterType<object, PayformsView>(View.PayformsView);
            _container.RegisterType<object, SalesFamiliesView>(View.SalesFamiliesView);
            _container.RegisterType<object, SalesFamilyGroupsView>(View.SalesFamilyGroupsView);
            _container.RegisterType<object, SalesItemsView>(View.SalesItemsView);
            _container.RegisterType<object, WaitersView>(View.WaitersView);
            _container.RegisterType<object, WaiterTeamsView>(View.WaiterTeamsView);

            _container.RegisterType<CurrenciesViewModel>();
            _container.RegisterType<DiscountsViewModel>();
            _container.RegisterType<PayformsViewModel>();
            _container.RegisterType<SalesFamiliesViewModel>();
            _container.RegisterType<SalesFamilyGroupsViewModel>();
            _container.RegisterType<SalesItemsViewModel>();
            _container.RegisterType<WaitersViewModel>();
            _container.RegisterType<WaiterTeamsViewModel>();
        }
    }
}