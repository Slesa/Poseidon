using System.Collections.ObjectModel;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel : IUsersViewModel
    {
        public ObservableCollection<User> Users { get; private set; }
    }
}