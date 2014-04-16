using Microsoft.Practices.Prism.Events;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UserRoleAddedEvent : CompositePresentationEvent<UserRole> { }
    public class UserRoleChangedEvent : CompositePresentationEvent<UserRole> { }
    public class UserRoleRemovedEvent : CompositePresentationEvent<int> { }

    public class UserAddedEvent : CompositePresentationEvent<User> { }
    public class UserChangedEvent : CompositePresentationEvent<User> { }
    public class UserRemovedEvent : CompositePresentationEvent<int> { }
}