using System.Collections.ObjectModel;
using Poseidon.Domain.Ums.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeUserRolesViewModel
    {
        public ObservableCollection<UserRole> UserRoles { get; private set; }

        public DesignTimeUserRolesViewModel()
        {
            UserRoles = new ObservableCollection<UserRole>()
                            {
                                new UserRole {Name = "Administrator"},
                                new UserRole {Name = "Operator"},
                                new UserRole {Name = "Waiter"},
                                new UserRole {Name = "Cashier"},
                            };
        }
    }
}