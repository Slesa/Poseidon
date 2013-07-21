using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Modules;
using Poseidon.BackOffice.Module.Ics.ViewModels;
using Poseidon.BackOffice.Module.Ics.Views;

namespace Poseidon.BackOffice.Module.Ics
{
    public class IcsModule : IModule
    {
        readonly IUnityContainer _container;

        public IcsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IcsOfficeModule>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IOfficeModule,ProductionItemModule>(ProductionItemModule.Name);
            _container.RegisterType<IOfficeModule,PurchaseItemModule>(PurchaseItemModule.Name);
            _container.RegisterType<IOfficeModule,PurchaseFamilyModule>(PurchaseFamilyModule.Name);
            _container.RegisterType<IOfficeModule,RecipeModule>(RecipeModule.Name);
            _container.RegisterType<IOfficeModule,StockModule>(StockModule.Name);
            _container.RegisterType<IOfficeModule,UnitModule>(UnitModule.Name);
            _container.RegisterType<IOfficeModule,UnitTypeModule>(UnitTypeModule.Name);

            _container.RegisterType<object, ProductionItemsView>(View.ProductionItemsView);
            _container.RegisterType<object, PurchaseItemsView>(View.PurchaseItemsView);
            _container.RegisterType<object, PurchaseFamiliesView>(View.PurchaseFamiliesView);
            _container.RegisterType<object, RecipesView>(View.RecipesView);
            _container.RegisterType<object, StocksView>(View.StocksView);
            _container.RegisterType<object, UnitsView>(View.UnitsView);
            _container.RegisterType<object, UnitTypesView>(View.UnitTypesView);
            _container.RegisterType<object, EditUnitTypeView>(View.EditUnitTypeView);

            _container.RegisterType<ProductionItemsViewModel>();
            _container.RegisterType<PurchaseItemsViewModel>();
            _container.RegisterType<PurchaseFamiliesViewModel>();
            _container.RegisterType<RecipesViewModel>();
            _container.RegisterType<StocksViewModel>();
            _container.RegisterType<UnitsViewModel>();
            _container.RegisterType<UnitTypesViewModel>();
            _container.RegisterType<EditUnitTypeViewModel>();
        }
    }
}