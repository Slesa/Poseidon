using System;
using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate;
using Poseidon.Domain.Ums.Hibernate.Maps;
using Poseidon.Domain.Ums.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Ums.Hibernate.Specs
{
    [Subject(typeof(TokenMap))]
    internal class When_checking_persistence_specs_of_token : InMemoryDatabaseSpecs<TokenMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Token>(Session);
                var type = new TokenType();
                spec.TransactionalSave(type);
                _check = spec
                    .CheckProperty(d => d.Key, "Token key")
                    .CheckProperty(d => d.TokenType, type)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<Token> _check;
    }


    [Subject(typeof(TokenMap))]
    internal class When_checking_persistence_specs_of_token_w_o_token_type : InMemoryDatabaseSpecs<TokenMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<Token>(Session);
                var check = spec
                    .CheckProperty(d => d.Key, "Token key")
                    .CheckProperty(d => d.Version, 1);
                _error = Catch.Exception(() => check.VerifyTheMappings());
            };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
}