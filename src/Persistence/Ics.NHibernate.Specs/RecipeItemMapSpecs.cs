using System;
using FluentNHibernate.Testing;
using Ics.Model;
using Ics.NHibernate.Maps;
using Machine.Specifications;
using NHibernate;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(RecipeItemMap))]
    public class When_checking_persistence_specs_of_recipe_item : InMemoryDatabaseSpecs<RecipeItemMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<RecipeItem>(Session);
                var unitType = new UnitType();
                specs.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                specs.TransactionalSave(unit);
                var item = new ProductionItem {RecipeUnit = unit};
                specs.TransactionalSave(item);
                var recipe = new Recipe();
                specs.TransactionalSave(recipe);
                _check = specs
                    .CheckProperty(d => d.Quantity, 1.125m)
                    .CheckProperty(d => d.Recipe, recipe)
                    .CheckProperty(d => d.RecipeableItem, item)
                    .CheckProperty(d => d.Unit, unit)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<RecipeItem> _check;
    }

    /*
    [Subject(typeof(RecipeItemMap))]
    public class When_checking_persistence_specs_of_recipe_item_w_o_recipe : InMemoryDatabaseSpecs<RecipeItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<RecipeItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var unit = new Unit { UnitType = unitType };
            specs.TransactionalSave(unit);
            var item = new ProductionItem { RecipeUnit = unit };
            specs.TransactionalSave(item);
            var check = specs
                .CheckProperty(d => d.Quantity, 1.125m)
                .CheckProperty(d => d.RecipeableItem, item)
                .CheckProperty(d => d.Unit, unit)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
    */

    [Subject(typeof(RecipeItemMap))]
    public class When_checking_persistence_specs_of_recipe_item_w_o_item : InMemoryDatabaseSpecs<RecipeItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<RecipeItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var unit = new Unit { UnitType = unitType };
            specs.TransactionalSave(unit);
            var recipe = new Recipe();
            specs.TransactionalSave(recipe);
            var check = specs
                .CheckProperty(d => d.Quantity, 1.125m)
                .CheckProperty(d => d.Recipe, recipe)
                .CheckProperty(d => d.Unit, unit)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }

    [Subject(typeof(RecipeItemMap))]
    public class When_checking_persistence_specs_of_recipe_item_w_o_unit : InMemoryDatabaseSpecs<RecipeItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<RecipeItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var unit = new Unit { UnitType = unitType };
            specs.TransactionalSave(unit);
            var item = new ProductionItem { RecipeUnit = unit };
            specs.TransactionalSave(item);
            var recipe = new Recipe();
            specs.TransactionalSave(recipe);
            var check = specs
                .CheckProperty(d => d.Quantity, 1.125m)
                .CheckProperty(d => d.Recipe, recipe)
                .CheckProperty(d => d.RecipeableItem, item)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
}