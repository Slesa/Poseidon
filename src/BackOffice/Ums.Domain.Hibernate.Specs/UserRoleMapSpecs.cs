using FluentNHibernate.Testing;
using Machine.Specifications;
using Poseidon.Hibernate.Specs.Common;
using Poseidon.Ums.Domain.Hibernate.Maps;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Specs
{
    [Subject(typeof(UserRoleMap))]
    class When_checking_persistence_specs_of_user_role : InMemoryDatabaseSpecs<UserRoleMap>
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