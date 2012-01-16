using BackOffice.Shared;
using Ums.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class UserRowViewModel : SelectableRowViewModelBase<User>
    {
        public UserRowViewModel(User user)
        {
            ElementData = user;
        }

        public string Name { get { return ElementData.Name; } }
        public UserRole UserRole { get { return ElementData.UserRole; } }
    }
}