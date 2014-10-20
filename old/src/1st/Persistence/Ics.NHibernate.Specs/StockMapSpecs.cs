using FluentNHibernate.Testing;
using FluentNHibernate.Utils;
using Ics.Model;
using Ics.NHibernate.Maps;
using Machine.Specifications;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(StockMap))]
    public class When_checking_persistence_specs_of_stock : InMemoryDatabaseSpecs<StockMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Stock>(Session);

                _check = spec
                    .CheckProperty(d => d.Name, "A stock")
                    .CheckProperty(d => d.IsMainStock, true)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Stock> _check;
    }

    [Subject(typeof(StockMap))]
    public class When_checking_persistence_specs_of_stock_w_items : InMemoryDatabaseSpecs<StockMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Stock>(Session);
                var unitType = new UnitType();
                spec.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                spec.TransactionalSave(unit);
                var productionItem = new ProductionItem {RecipeUnit = unit};
                spec.TransactionalSave(productionItem);

                var stockItems = new[]
                    {
                        new StockItem(0.425m, productionItem){Unit=unit},
                        new StockItem(0.827m, productionItem){Unit=unit},
                    };

                _check = spec
                    .CheckProperty(d => d.Name, "A stock")
                    .CheckProperty(d => d.IsMainStock, true)
                    .CheckList(d => d.StockItems, stockItems, (stock, items) => items.Each(stock.AddStockItem))
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Stock> _check;
    }
}