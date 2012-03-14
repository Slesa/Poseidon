using FluentNHibernate.Testing;
using FluentNHibernate.Utils;
using Ics.Model;
using Ics.NHibernate.Maps;
using Machine.Specifications;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(ProductionItemMap))]
    public class When_checking_persistence_specs_of_production_item : InMemoryDatabaseSpecs<ProductionItemMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<ProductionItem>(Session);
                var unitType = new UnitType();
                spec.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                spec.TransactionalSave(unit);
                _check = spec
                    .CheckProperty(d => d.Name, "A production item")
                    .CheckReference(d =>d.RecipeUnit, unit)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<ProductionItem> _check;
    }

    [Subject(typeof(ProductionItemMap))]
    public class When_checking_persistence_specs_of_production_item_w_items : InMemoryDatabaseSpecs<ProductionItemMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<ProductionItem>(Session);
                var unitType = new UnitType();
                spec.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                spec.TransactionalSave(unit);
                var productionItem = new ProductionItem {RecipeUnit = unit};
                spec.TransactionalSave(productionItem);

                var recipeItems = new[]
                    {
                        new RecipeItem(0.425m, productionItem) {Unit = unit},
                        new RecipeItem(0.875m, productionItem) {Unit = unit},
                    };

                _check = spec
                    .CheckProperty(d => d.Name, "A production item")
                    .CheckReference(d =>d.RecipeUnit, unit)
                    .CheckList(d =>d.RecipeItems, recipeItems, (Recipe,items) => items.Each(Recipe.AddRecipeItem))
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<ProductionItem> _check;
    }
}