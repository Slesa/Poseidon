using Ums.Model;

namespace Poseidon.Ums.OfficeModule.Events
{
    public class UserRoleChangedEvent
    {
        public UserRoleChangedEvent(UserRole userRole)
        {
            UserRole = userRole;
        }

        protected UserRole UserRole { get; private set; }
    }

    public class UserRoleRemovedEvent
    {
        public UserRoleRemovedEvent(int id)
        {
            Id = id;
        }

        protected int Id { get; private set; }
    }
}