﻿using FluentNHibernate.Testing;
using FluentNHibernate.Utils;
using Machine.Specifications;
using Poseidon.Domain.Ics.Hibernate.Maps;
using Poseidon.Domain.Ics.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Ics.Hibernate.Specs
{
    [Subject(typeof(RecipeMap))]
    internal class When_checking_persistence_specs_of_recipe_map : InMemoryDatabaseSpecs<RecipeMap>
    {
        static PersistenceSpecification<Recipe> _check;

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
                                          new RecipeItem(0.42m, productionItem),
                                          new RecipeItem(0.84m, productionItem),
                                      };

                _check = spec
                    .CheckProperty(c => c.Plu, 42)
                    //.CheckReference(c => c.SalesItem, salesItem)
                    .CheckList(c => c.RecipeItems, recipeItems, (rec, items) => items.Each(rec.AddRecipeItem));
            };

        It should_be_verified = () => _check.VerifyTheMappings();
    }
}