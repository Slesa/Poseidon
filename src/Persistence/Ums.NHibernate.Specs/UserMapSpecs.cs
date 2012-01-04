using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Ums.Model;

namespace Ums.NHibernate.Specs
{
    [Subject(typeof(UserMap))]
    public class When_checking_persistence_specs_of_user : InMemoryDatabaseSpecs<UserMap>
    {
        Because of = () =>
            {
                var spec = new PersistenceSpecification<User>(Session);
                _check = spec
                    .CheckProperty(d => d.Name, "A user")
                    .CheckProperty(d => d.Version, 1);
            };

        It should_be_verified = () => _check.VerifyTheMappings();

        static PersistenceSpecification<User> _check;

    }
}