using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Domain.Ums.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(WaiterMap))]
    public class When_checking_persistence_specs_of_waiter : InMemoryDatabaseSpecs<WaiterMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Waiter>(Session);
                //var user = new User();
                //spec.TransactionalSave(user);
                var waiterTeam = new WaiterTeam();
                spec.TransactionalSave(waiterTeam);
                _check = spec
                    //.CheckReference(d => d.User, user)
                    .CheckReference(d => d.WaiterTeam, waiterTeam)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Waiter> _check;
    }
}