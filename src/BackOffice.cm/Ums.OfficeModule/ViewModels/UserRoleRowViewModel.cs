using BackOffice.Shared.ViewModels;
using Ums.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class UserRoleRowViewModel : SelectableRowViewModelBase<UserRole>
    {
        public UserRoleRowViewModel(UserRole userRole)
        {
            ElementData = userRole;
        }

        public int Id { get { return ElementData.Id; } }
        public string Name { get { return ElementData.Name; } }

    }
}