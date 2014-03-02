using System.Collections.ObjectModel;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel
    {
        public ObservableCollection<User> Users { get; set; }
    }
}