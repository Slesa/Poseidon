using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Pms.Model;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate.Specs
{
    [Subject(typeof(SalesItemMap))]
    public class When_checking_persistence_specs_of_sales_item : InMemoryDatabaseSpecs<SalesItemMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<SalesItem>(Session);
                var salesFamily = new SalesFamily();
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