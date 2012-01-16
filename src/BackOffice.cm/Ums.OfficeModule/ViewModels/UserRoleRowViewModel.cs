using BackOffice.Shared;
using Ums.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class UserRoleRowViewModel : SelectableRowViewModelBase<UserRole>
    {
        public UserRoleRowViewModel(UserRole userRole)
        {
            ElementData = userRole;
        }

        public string Name { get { return ElementData.Name; } }
    }
}