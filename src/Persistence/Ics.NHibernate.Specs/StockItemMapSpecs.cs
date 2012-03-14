using System;
using FluentNHibernate.Testing;
using Ics.Model;
using Ics.NHibernate.Maps;
using Machine.Specifications;
using NHibernate;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(StockItemMap))]
    public class When_checking_persistence_specs_of_stock_item : InMemoryDatabaseSpecs<StockItemMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<StockItem>(Session);
                var unitType = new UnitType();
                specs.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                specs.TransactionalSave(unit);
                var item = new ProductionItem {RecipeUnit = unit};
                specs.TransactionalSave(item);
                var stock = new Stock();
                specs.TransactionalSave(stock);
                _check = specs
                    .CheckProperty(d => d.Quantity, 1.125m)
                    .CheckProperty(d => d.Stock, stock)
                    .CheckProperty(d => d.RecipeableItem, item)
                    .CheckProperty(d => d.Unit, unit)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<StockItem> _check;
    }

    [Subject(typeof(StockItemMap)), Ignore("With .stock.not.null, inserting stock items does not work")]
    public class When_checking_persistence_specs_of_stock_item_w_o_stock : InMemoryDatabaseSpecs<StockItemMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<StockItem>(Session);
                var unitType = new UnitType();
                specs.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                specs.TransactionalSave(unit);
                var item = new ProductionItem {RecipeUnit = unit};
                specs.TransactionalSave(item);
                var check = specs
                    .CheckProperty(d => d.Quantity, 1.125m)
                    .CheckProperty(d => d.RecipeableItem, item)
                    .CheckProperty(d => d.Unit, unit)
                    .CheckProperty(d => d.Version, 1);
                _error = Catch.Exception(()=>check.VerifyTheMappings());
            };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }

    [Subject(typeof(StockItemMap))]
    public class When_checking_persistence_specs_of_stock_item_w_o_item : InMemoryDatabaseSpecs<StockItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<StockItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var unit = new Unit { UnitType = unitType };
            specs.TransactionalSave(unit);
            var stock = new Stock();
            specs.TransactionalSave(stock);
            var check = specs
                .CheckProperty(d => d.Quantity, 1.125m)
                .CheckProperty(d => d.Stock, stock)
                .CheckProperty(d => d.Unit, unit)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }

    [Subject(typeof(StockItemMap))]
    public class When_checking_persistence_specs_of_stock_item_w_o_unit : InMemoryDatabaseSpecs<StockItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<StockItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var unit = new Unit { UnitType = unitType };
            specs.TransactionalSave(unit);
            var item = new ProductionItem { RecipeUnit = unit };
            specs.TransactionalSave(item);
            var stock = new Stock();
            specs.TransactionalSave(stock);
            var check = specs
                .CheckProperty(d => d.Quantity, 1.125m)
                .CheckProperty(d => d.Stock, stock)
                .CheckProperty(d => d.RecipeableItem, item)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
}