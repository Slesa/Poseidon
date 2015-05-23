using Microsoft.Practices.Prism.PubSubEvents;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UserRoleAddedEvent : PubSubEvent<UserRole> { }
    public class UserRoleChangedEvent : PubSubEvent<UserRole> { }
    public class UserRoleRemovedEvent : PubSubEvent<int> { }

    public class UserAddedEvent : PubSubEvent<User> { }
    public class UserChangedEvent : PubSubEvent<User> { }
    public class UserRemovedEvent : PubSubEvent<int> { }
}