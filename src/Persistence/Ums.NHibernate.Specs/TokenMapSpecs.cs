using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Ums.Model;

namespace Ums.NHibernate.Specs
{
    [Subject(typeof(TokenMap))]
    public class When_checking_persistence_specs_of_token : InMemoryDatabaseSpecs<TokenMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Token>(Session);
                _check = spec
                    .CheckProperty(d => d.Key, "Any key")
                    .CheckProperty(d => d.Type, 1);
            };

        It should_be_verfied = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Token> _check;
    }
}