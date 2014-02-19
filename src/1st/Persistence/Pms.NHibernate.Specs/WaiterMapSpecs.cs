using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Pms.Model.Entities;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate.Specs
{
    [Subject(typeof(WaiterMap))]
    public class When_checking_persistence_specs_of_waiter : InMemoryDatabaseSpecs<WaiterMap>
    {
        Because of = () =>
        {
            var spec = new PersistenceSpecification<Waiter>(Session);
            var waiterTeam = new WaiterTeam();
            spec.TransactionalSave(waiterTeam);
            _check = spec
                .CheckReference(d => d.WaiterTeam, waiterTeam)
                .CheckProperty(d => d.Version, 1);
        };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Waiter> _check;
    }
}