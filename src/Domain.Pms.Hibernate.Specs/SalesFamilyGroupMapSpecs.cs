using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(SalesFamilyGroupMap))]
    public class When_checking_persistence_specs_of_sales_family_group : InMemoryDatabaseSpecs<SalesFamilyGroupMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<SalesFamilyGroup>(Session);
                _check = specs
                    .CheckProperty(d => d.Name, "A sales family group")
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<SalesFamilyGroup> _check;
    }
}