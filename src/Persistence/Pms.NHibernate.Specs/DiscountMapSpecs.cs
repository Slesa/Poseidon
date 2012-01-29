using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Pms.Model;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate.Specs
{
    [Subject(typeof(DiscountMap))]
    public class When_checking_persistence_specs_of_discount : InMemoryDatabaseSpecs<DiscountMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Discount>(Session);
                _check = spec
                    .CheckProperty(d => d.Name, "A discount")
                    .CheckProperty(d => d.Rate, 1.125m)
                    .CheckProperty(d => d.IsAbsolute, true)
                    .CheckProperty(d => d.UseForOrders, true)
                    .CheckProperty(d => d.UseForSale, false)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Discount> _check;
    }
}