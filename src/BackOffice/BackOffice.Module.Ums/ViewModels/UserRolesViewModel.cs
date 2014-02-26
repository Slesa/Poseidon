using System.Collections.ObjectModel;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UserRolesViewModel : IUserRolesViewModel
    {
        public ObservableCollection<UserRole> UserRoles { get; private set; }
    }
}