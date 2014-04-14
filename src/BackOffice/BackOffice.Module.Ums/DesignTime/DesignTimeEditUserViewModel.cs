using System.Collections.Generic;
using System.Linq;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeEditUserViewModel
    {
        public DesignTimeEditUserViewModel()
        {
            AllUserRoles = DesignTimeUserRolesViewModel.CreateUserRoles().ToList();
            UserRole = AllUserRoles.First();
            Name = "Jean-Luc Picard";
        }

        public string Name { get; set; }
        public UserRole UserRole { get; set; }
        public List<UserRole> AllUserRoles { get; private set; }
    }
}