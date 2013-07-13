using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(WaiterTeamMap))]
    public class When_checking_persistence_specs_of_waiter_team : InMemoryDatabaseSpecs<WaiterTeamMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<WaiterTeam>(Session);
                _check = specs
                    .CheckProperty(d => d.Name, "A waiter team")
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<WaiterTeam> _check;
    }
}