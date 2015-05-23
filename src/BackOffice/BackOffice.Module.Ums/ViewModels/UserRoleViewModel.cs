using Microsoft.Practices.Prism.Mvvm;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UserRoleViewModel : BindableBase
    {
        readonly UserRole _userRole;

        public UserRoleViewModel(UserRole userRole)
        {
            _userRole = userRole;
        }

        public void UseDataFrom(UserRole userRole)
        {
            Name = userRole.Name;
        }

        public int Id
        {
            get { return _userRole.Id; }
        }

        public string Name
        {
            get { return _userRole.Name; }
            set
            {
                _userRole.Name = value;
                OnPropertyChanged(()=>Name);
            }
        }
    }
}