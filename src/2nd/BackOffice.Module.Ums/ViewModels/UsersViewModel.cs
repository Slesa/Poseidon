using System.Collections.ObjectModel;
using Poseidon.Domain.Ums.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel
    {
        public ObservableCollection<User> Users { get; set; }
    }
}