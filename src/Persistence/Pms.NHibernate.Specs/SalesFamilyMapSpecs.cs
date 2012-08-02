using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Pms.Model.Entities;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate.Specs
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