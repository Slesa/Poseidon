using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(SalesFamilyMap))]
    public class When_checking_persistence_specs_of_sales_family : InMemoryDatabaseSpecs<SalesFamilyMap>
    {
        Because of = () =>
            {
                var specs = new PersistenceSpecification<SalesFamily>(Session);
                var salesFamilyGroup = new SalesFamilyGroup();
                specs.TransactionalSave(salesFamilyGroup);
                _check = specs
                    .CheckProperty(d => d.Name, "A sales family")
                    .CheckReference(d => d.SalesFamilyGroup, salesFamilyGroup)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<SalesFamily> _check;
    }
}