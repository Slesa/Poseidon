using System;
using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate;
using Poseidon.Domain.Ums.Hibernate.Maps;
using Poseidon.Domain.Ums.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Ums.Hibernate.Specs
{
    [Subject(typeof(UserMap))]
    public class When_checking_persistence_specs_of_user : InMemoryDatabaseSpecs<UserMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<User>(Session);
                var role = new UserRole();
                spec.TransactionalSave(role);
                _check = spec
                    .CheckProperty(d => d.Name, "A user")
                    .CheckProperty(d => d.UserRole, role)
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<User> _check;
    }


    [Subject(typeof(UserMap))]
    public class When_checking_persistence_specs_of_user_w_o_user_role : InMemoryDatabaseSpecs<UserMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<User>(Session);
                var check = spec
                    .CheckProperty(d => d.Name, "A user")
                    .CheckProperty(d => d.Version, 1);
                _error = Catch.Exception(() => check.VerifyTheMappings());
            };

        It should_fail = () => _error.ShouldBeOfType(typeof(PropertyValueException));

        static Exception _error;
    }
}