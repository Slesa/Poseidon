using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Domain.Ums.Hibernate.Maps;
using Poseidon.Domain.Ums.Model;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Domain.Ums.Hibernate.Specs
{
    [Subject(typeof(UserRoleMap))]
    internal class When_checking_persistence_specs_of_user_role : InMemoryDatabaseSpecs<UserRoleMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<UserRole>(Session);
                _check = spec
                    .CheckProperty(c => c.Name, "A user role")
                    .CheckProperty(c => c.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<UserRole> _check;
    }
}