using System.Collections.ObjectModel;
using Poseidon.Domain.Ums.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeUsersViewModel
    {
        public ObservableCollection<User> Users { get; private set; }

        public DesignTimeUsersViewModel()
        {
            var admin = new UserRole {Name = "Administrator"};
            var operate = new UserRole {Name = "Operator"};
            var user = new UserRole {Name = "User"};

            Users = new ObservableCollection<User>()
                            {
                                new User {Name = "root", UserRole = admin},
                                new User {Name = "user", UserRole = user},
                                new User {Name = "John Doe", UserRole = user},
                                new User {Name = "Jabba The Hut", UserRole = operate},
                            };
        }
    }
}