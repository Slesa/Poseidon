using Microsoft.Practices.Prism.ViewModel;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UserViewModel : NotificationObject
    {
        readonly User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public void UseDataFrom(User user)
        {
            Name = user.Name;
            UserRole = user.UserRole;
        }

        public int Id
        {
            get { return _user.Id; }
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public UserRole UserRole
        {
            get { return _user.UserRole; }
            set
            {
                _user.UserRole = value;
                RaisePropertyChanged(() => UserRole);
            }
        }
    }
}