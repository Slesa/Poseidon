using FluentNHibernate.Testing;
using Ics.Model;
using Machine.Specifications;
using NHibernate.Specs.Shared;

namespace Ics.NHibernate.Specs
{
    [Subject(typeof(PurchaseFamilyMap))]
    public class When_checking_persistence_spec_of_purchase_family : InMemoryDatabaseSpecs<PurchaseFamilyMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<PurchaseFamily>(Session);
                _check = spec
                    .CheckProperty(d => d.Name, "A purchase family")
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<PurchaseFamily> _check;
    }
}