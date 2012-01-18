using System.ComponentModel;
using BackOffice.Shared.ViewModels;
using Persistence.Shared;
using Ums.Model;
using Ums.OfficeModule.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class EditUserRoleViewModel : EditItemViewModel<UserRoleModel>, IDataErrorInfo
    {
        static public EditUserRoleViewModel CreateViewModel(IDbConversation dbConversation)
        {
            var viewModel = new EditUserRoleViewModel(dbConversation);
            viewModel.Element = new UserRoleModel();
            viewModel.DisplayName = "Add new user role...";
            return viewModel;
        }

        static public EditUserRoleViewModel CreateViewModel(int userRoleId, IDbConversation dbConversation)
        {
            var viewModel = new EditUserRoleViewModel(dbConversation);
            dbConversation.UsingTransaction(()=>
                viewModel.Element = new UserRoleModel(dbConversation.GetById<UserRole>(userRoleId)));
            viewModel.DisplayName = "Edit user role";
            return viewModel;
        }

        EditUserRoleViewModel(IDbConversation dbConversation) 
            : base(dbConversation)
        {
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
    }
}