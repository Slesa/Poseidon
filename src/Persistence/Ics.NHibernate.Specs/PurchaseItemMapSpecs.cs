using System;
using FluentNHibernate.Testing;
using Ics.Model;
using Machine.Specifications;
using NHibernate;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(PurchaseItemMap))]
    public class When_checking_persistence_specs_of_purchase_item : InMemoryDatabaseSpecs<PurchaseItemMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<PurchaseItem>(Session);
                var unitType = new UnitType();
                specs.TransactionalSave(unitType);
                var recipeUnit = new Unit {UnitType = unitType};
                specs.TransactionalSave(recipeUnit);
                var purchaseUnit = new Unit {UnitType = unitType};
                specs.TransactionalSave(purchaseUnit);
                var family = new PurchaseFamily();
                specs.TransactionalSave(family);
                _check = specs
                    .CheckProperty(d => d.Name, "A purchase item")
                    .CheckProperty(d =>d.RecipeUnit, recipeUnit)
                    .CheckProperty(d =>d.PurchaseUnit, purchaseUnit)
                    .CheckProperty(d=>d.PurchaseFamily, family)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<PurchaseItem> _check;
    }

    [Subject(typeof(PurchaseItemMap))]
    public class When_checking_persistence_specs_of_purchase_item_w_o_purchase_unit : InMemoryDatabaseSpecs<PurchaseItemMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<PurchaseItem>(Session);
                var unitType = new UnitType();
                specs.TransactionalSave(unitType);
                var recipeUnit = new Unit {UnitType = unitType};
                specs.TransactionalSave(recipeUnit);
                var purchaseUnit = new Unit {UnitType = unitType};
                specs.TransactionalSave(purchaseUnit);
                var family = new PurchaseFamily();
                specs.TransactionalSave(family);
                var check = specs
                    .CheckProperty(d => d.Name, "A purchase item")
                    .CheckProperty(d =>d.RecipeUnit, recipeUnit)
                    .CheckProperty(d=>d.PurchaseFamily, family)
                    .CheckProperty(d => d.Version, 1);
                _error = Catch.Exception(() => check.VerifyTheMappings());
            };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }

    [Subject(typeof(PurchaseItemMap))]
    public class When_checking_persistence_specs_of_purchase_item_w_o_recipe_unit : InMemoryDatabaseSpecs<PurchaseItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<PurchaseItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var recipeUnit = new Unit { UnitType = unitType };
            specs.TransactionalSave(recipeUnit);
            var purchaseUnit = new Unit { UnitType = unitType };
            specs.TransactionalSave(purchaseUnit);
            var family = new PurchaseFamily();
            specs.TransactionalSave(family);
            var check = specs
                .CheckProperty(d => d.Name, "A purchase item")
                .CheckProperty(d => d.PurchaseUnit, purchaseUnit)
                .CheckProperty(d => d.PurchaseFamily, family)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }

    [Subject(typeof(PurchaseItemMap))]
    public class When_checking_persistence_specs_of_purchase_item_w_o_family : InMemoryDatabaseSpecs<PurchaseItemMap>
    {
        Because of = () =>
        {
            var specs = new PersistenceSpecification<PurchaseItem>(Session);
            var unitType = new UnitType();
            specs.TransactionalSave(unitType);
            var recipeUnit = new Unit { UnitType = unitType };
            specs.TransactionalSave(recipeUnit);
            var purchaseUnit = new Unit { UnitType = unitType };
            specs.TransactionalSave(purchaseUnit);
            var family = new PurchaseFamily();
            specs.TransactionalSave(family);
            var check = specs
                .CheckProperty(d => d.Name, "A purchase item")
                .CheckProperty(d => d.RecipeUnit, recipeUnit)
                .CheckProperty(d => d.PurchaseUnit, purchaseUnit)
                .CheckProperty(d => d.Version, 1);
            _error = Catch.Exception(() => check.VerifyTheMappings());
        };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
}