using FluentNHibernate.Testing;
using FluentNHibernate.Utils;
using Ics.Model;
using Ics.NHibernate.Maps;
using Machine.Specifications;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(RecipeMap))]
    public class When_checking_persistence_specs_of_recipe : InMemoryDatabaseSpecs<RecipeMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Recipe>(Session);
                _check = spec
                    .CheckProperty(d => d.Plu, 42)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Recipe> _check;
    }

    [Subject(typeof(RecipeMap))]
    public class When_checking_persistence_specs_of_recipe_w_items : InMemoryDatabaseSpecs<RecipeMap>
    {
        Because of = () =>
        {
            var spec = new PersistenceSpecification<Recipe>(Session);
            var unitType = new UnitType();
            spec.TransactionalSave(unitType);
            var unit = new Unit {UnitType = unitType};
            spec.TransactionalSave(unit);
            var productionItem = new ProductionItem {RecipeUnit = unit};
            spec.TransactionalSave(productionItem);

            var recipeItems = new[]
                {
                    new RecipeItem(0.425m, productionItem) {Unit = unit},
                    new RecipeItem(1.857m, productionItem) {Unit = unit},
                };

            _check = spec
                .CheckProperty(d => d.Plu, 42)
                .CheckList(d =>d.RecipeItems, recipeItems, (recipe,items) => items.Each(recipe.AddRecipeItem))
                .CheckProperty(d => d.Version, 1);
        };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Recipe> _check;
    }
}