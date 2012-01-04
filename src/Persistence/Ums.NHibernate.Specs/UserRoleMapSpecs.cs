using FluentNHibernate.Testing;
using Machine.Specifications;
using NHibernate.Specs.Shared;
using Ums.Model;

namespace Ums.NHibernate.Specs
{
    [Subject(typeof(UserRoleMap))]
    public class When_checking_persistence_specs_of_user_role : InMemoryDatabaseSpecs<UserRoleMap>
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

    [Subject(typeof(UserRoleMap))]
    public class When_saving_user_role : InMemoryDatabaseSpecs<UserRoleMap>
    {
        Establish context = () =>
            {
                var userRole = new UserRole();
                userRole.Name = "A user role";
                _index = (int) Session.Save(userRole);
            };

        Because of = () =>
            {
                var userRole = Session.Load<UserRole>(_index);
                _name = userRole.Name;
            };

        It should_be_saved = () => _name.ShouldEqual("A user role");

        static int _index;
        static string _name;
    }

}
