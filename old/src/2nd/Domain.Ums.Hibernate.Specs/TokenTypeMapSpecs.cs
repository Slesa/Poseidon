using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Ums.Hibernate.Maps;
using Poseidon.Hibernate.Specs.Common;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Domain.Ums.Hibernate.Specs
{
    [Subject(typeof(TokenTypeMap))]
    internal class When_checking_persistence_specs_of_token_type : InMemoryDatabaseSpecs<TokenTypeMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<TokenType>(Session);
                _check = spec
                    .CheckProperty(c => c.Name, "A token type")
                    .CheckProperty(c => c.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<TokenType> _check;
    }
}