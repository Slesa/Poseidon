using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(PayformMap))]
    internal class When_checking_persistence_specs_of_payform : InMemoryDatabaseSpecs<PayformMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Payform>(Session);
                _check = spec
                    .CheckProperty(d => d.Name, "A payform")
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Payform> _check;
    }
}