using System.Collections.Generic;
using System.Collections.ObjectModel;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeUsersViewModel : IUsersViewModel
    {
        public ObservableCollection<User> Users
        {
            get
            {
                return new ObservableCollection<User>(CreateUsers());
            }
        }

        IEnumerable<User> CreateUsers()
        {
            yield return new User {Name = "Jean-Luc Picard", UserRole = new UserRole {Name = "Captain"}};
            yield return new User {Name = "Worf", UserRole = new UserRole {Name = "Commander"}};
            yield return new User {Name = "Riker", UserRole = new UserRole {Name = "Ltd Commander"}};
        }
    }
}