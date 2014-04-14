using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeUserRolesViewModel : IUserRolesViewModel
    {
        public ObservableCollection<UserRole> UserRoles
        {
            get
            {
                return new ObservableCollection<UserRole>(CreateUserRoles());
            }
        }

        public ICommand AddNewUserRoleCommand { get { return null; } }

        public static IEnumerable<UserRole> CreateUserRoles()
        {
            yield return new UserRole { Name = "Captain" };
            yield return new UserRole { Name = "Lieutenant" };
            yield return new UserRole { Name = "Lieutenant Commander" };
        }
    }
}