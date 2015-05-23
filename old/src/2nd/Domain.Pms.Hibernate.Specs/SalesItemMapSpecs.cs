using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(SalesItemMap))]
    internal class When_checking_persistence_specs_of_sales_item : InMemoryDatabaseSpecs<SalesItemMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<SalesItem>(Session);
                var salesFamilyGroup = new SalesFamilyGroup();
                spec.TransactionalSave(salesFamilyGroup);
                var salesFamily = new SalesFamily {SalesFamilyGroup = salesFamilyGroup};
                spec.TransactionalSave(salesFamily);
                _check = spec
                    .CheckProperty(d => d.Name, "A sales item")
                    .CheckReference(d => d.SalesFamily, salesFamily)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<SalesItem> _check;
    }
}