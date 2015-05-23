using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Pms.Model.Entities;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate.Specs
{
    [Subject(typeof(PayformMap))]
    public class When_checking_persistence_specs_of_payform : InMemoryDatabaseSpecs<PayformMap>
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