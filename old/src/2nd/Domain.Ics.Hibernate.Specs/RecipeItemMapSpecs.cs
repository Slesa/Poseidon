using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Ics.Hibernate.Maps;
using Poseidon.Domain.Ics.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Ics.Hibernate.Specs
{
    [Subject(typeof(RecipeItemMap))]
    internal class When_checking_persistence_specs_of_recipe_item : InMemoryDatabaseSpecs<RecipeItemMap>
    {
        static PersistenceSpecification<RecipeItem> _check;

        Because of = () =>
            {
                var spec = new PersistenceSpecification<RecipeItem>(Session);
                var unitType = new UnitType();
                spec.TransactionalSave(unitType);
                var unit = new Unit {UnitType = unitType};
                spec.TransactionalSave(unit);
                var item = new ProductionItem {RecipeUnit = unit};
                spec.TransactionalSave(item);

                _check = spec
                    .CheckProperty(c => c.Quantity, 1.42m)
                    .CheckReference(c => c.Recipe, new Recipe())
                    .CheckReference(c => c.RecipeableItem, item)
                    .CheckReference(c => c.Unit, unit);
            };

        It should_be_verified = () => _check.VerifyTheMappings();
    }
}