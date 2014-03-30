using System.Collections.ObjectModel;
using System.Windows.Input;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.Contracts
{
    public interface IUserRolesViewModel
    {
        ObservableCollection<UserRole> UserRoles { get; }
        ICommand AddNewUserRoleCommand { get; }
    }
}