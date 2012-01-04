using FluentNHibernate.Testing;
using Ics.Model;
using Machine.Specifications;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(UnitTypeMap))]
    public class When_checking_persistence_specs_of_unit_type : InMemoryDatabaseSpecs<UnitTypeMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<UnitType>(Session);
                _check = spec
                    .CheckProperty(d => d.Name, "A unit type")
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<UnitType> _check;
    }
}
