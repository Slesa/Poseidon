using Ums.Model;

namespace Poseidon.Ums.OfficeModule.Events
{
    public class UserChangedEvent
    {
        public UserChangedEvent(User user)
        {
            User = user;
        }

        protected User User { get; private set; }
    }

    public class UserRemovedEvent
    {
        public UserRemovedEvent(int id)
        {
            Id = id;
        }

        protected int Id { get; private set; }
    }
}