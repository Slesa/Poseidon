using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Pms.Hibernate.Maps;
using Poseidon.Domain.Pms.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Pms.Hibernate.Specs
{
    [Subject(typeof(CurrencyMap))]
    public class When_checking_persistence_specs_of_currency : InMemoryDatabaseSpecs<CurrencyMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Currency>(Session);
                _check = spec
                    .CheckProperty(d => d.Name, "A currency")
                    .CheckProperty(d => d.Contraction, "acurr")
                    .CheckProperty(d => d.Symbol, "§")
                    .CheckProperty(d => d.Rate, 1.25m)
                    .CheckProperty(d => d.DecimalChar, ',')
                    .CheckProperty(d => d.DecimalPosition, 2)
                    .CheckProperty(d => d.ThousandChar, '.')
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Currency> _check;
    }
}