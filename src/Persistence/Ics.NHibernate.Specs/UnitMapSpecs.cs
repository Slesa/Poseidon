using System;
using FluentNHibernate.Testing;
using Ics.Model;
using Machine.Specifications;
using NHibernate;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(UnitMap))]
    public class When_checking_persistence_specs_of_unit : InMemoryDatabaseSpecs<UnitMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Unit>(Session);
                var type = new UnitType {Name = "Any type"};
                spec.TransactionalSave(type);
                var parent = new Unit { Name = "Parent unit", UnitType = type};
                spec.TransactionalSave(parent);
                _check = spec
                    .CheckProperty(d => d.Name, "A unit")
                    .CheckProperty(d => d.Contraction, "au")
                    .CheckProperty(d => d.Parent, parent)
                    .CheckProperty(d => d.UnitType, type)
                    .CheckProperty(d => d.FactorToParent, 1.0m)
                    .CheckProperty(d => d.ForPurchase, true)
                    .CheckProperty(d => d.ForRecipe, true)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Unit> _check;
    }

    [Subject(typeof(UnitMap))]
    public class When_checking_persistence_specs_of_unit_w_o_parent : InMemoryDatabaseSpecs<UnitMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Unit>(Session);
                var type = new UnitType {Name = "Any type"};
                spec.TransactionalSave(type);
                _check = spec
                    .CheckProperty(d => d.Name, "A unit")
                    .CheckProperty(d => d.Contraction, "au")
                    .CheckProperty(d => d.UnitType, type)
                    .CheckProperty(d => d.FactorToParent, 1.0m)
                    .CheckProperty(d => d.ForPurchase, true)
                    .CheckProperty(d => d.ForRecipe, true)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Unit> _check;
    }

    [Subject(typeof(UnitMap))]
    public class When_checking_persistence_specs_of_unit_w_o_type : InMemoryDatabaseSpecs<UnitMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Unit>(Session);
                var check = spec
                    .CheckProperty(d => d.Name, "A unit")
                    .CheckProperty(d => d.Contraction, "au")
                    .CheckProperty(d => d.FactorToParent, 1.0m)
                    .CheckProperty(d => d.ForPurchase, true)
                    .CheckProperty(d => d.ForRecipe, true)
                    .CheckProperty(d => d.Version, 1);
                _error = Catch.Exception(() => check.VerifyTheMappings());
            };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
}