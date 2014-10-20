using System.ComponentModel;
using BackOffice.Shared.ViewModels;
using Ums.Model;
using Ums.OfficeModule.Model;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.ViewModels
{
    public sealed class EditUserRoleViewModel : EditItemViewModel<UserRoleModel>, IDataErrorInfo
    {
        public EditUserRoleViewModel() 
        {
            Element = new UserRoleModel();
            DisplayName = Strings.EditUserRole_AddNewUserRole;
        }

        public EditUserRoleViewModel(int userRoleId) 
        {
            DbConversation.UsingTransaction(() =>
                Element = new UserRoleModel(DbConversation.GetById<UserRole>(userRoleId)));
            DisplayName = Strings.EditUserRole_EditUserRole;
        }

        public string Name
        {
            get { return Element.Name; }
            set
            {
                if (value == Element.Name) return;
                Element.Name = value;
                NotifyOfPropertyChange(()=>Name);
            }
        }

        public void Save()
        {
            if (!SuccessfullySaved(() => DbConversation.Insert(Element.UserRole)))
                return;
            EventAggregator.Publish(new UserRoleChangedEvent(Element.UserRole));
            TryClose();
        }
    }
}