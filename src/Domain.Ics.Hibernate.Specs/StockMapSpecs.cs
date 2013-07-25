using FluentNHibernate.Testing;
using FluentNHibernate.Utils;
using Machine.Specifications;
using Poseidon.Domain.Ics.Hibernate.Maps;
using Poseidon.Domain.Ics.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Ics.Hibernate.Specs
{
    [Subject(typeof(StockMap))]
    internal class When_checking_persistence_specs_of_stock_map : InMemoryDatabaseSpecs<StockMap>
    {
        static PersistenceSpecification<Stock> _check;

        Because of = () =>
        {
            var spec = new PersistenceSpecification<StockItem>(Session);

            var unitType = new UnitType();
            spec.TransactionalSave(unitType);
            var unit = new Unit { UnitType = unitType };
            spec.TransactionalSave(unit);
            var productionItem = new ProductionItem { RecipeUnit = unit };
            spec.TransactionalSave(productionItem);

            var stockItems = new[]
                {
                    new StockItem(0.42m, productionItem) , 
                    new StockItem(0.84m, productionItem) ,
                };

            _check = new PersistenceSpecification<Stock>(Session)
                .CheckProperty(c => c.Name, "Stock One")
                .CheckList(c => c.StockItems, stockItems, (st, items) => items.Each(st.AddStockItem));
        };

        It should_be_verified = () => _check.VerifyTheMappings();
    }
}