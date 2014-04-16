using System.Collections.Generic;
using System.Collections.ObjectModel;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeUserRolesViewModel
    {
        public ObservableCollection<UserRole> UserRoles
        {
            get
            {
                return new ObservableCollection<UserRole>(CreateUserRoles());
            }
        }

        public static IEnumerable<UserRole> CreateUserRoles()
        {
            yield return new UserRole { Name = "Captain" };
            yield return new UserRole { Name = "Lieutenant" };
            yield return new UserRole { Name = "Lieutenant Commander" };
        }
    }
}