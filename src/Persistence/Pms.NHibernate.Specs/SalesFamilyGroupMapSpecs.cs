using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Pms.Model.Entities;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate.Specs
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