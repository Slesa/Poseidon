using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BackOffice.Shared.ViewModels;
using Persistence.Shared;
using Ums.Model;
using Ums.NHibernate.Queries;
using Ums.OfficeModule.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class EditUserViewModel : EditItemViewModel<UserModel>, IDataErrorInfo
    {
        static public EditUserViewModel CreateViewModel(IDbConversation dbConversation)
        {
            var viewModel = new EditUserViewModel(dbConversation);
            viewModel.Element = new UserModel();
            viewModel.DisplayName = "Add new user...";
            viewModel.AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList();
            return viewModel;
        }

        static public EditUserViewModel CreateViewModel(int userId, IDbConversation dbConversation)
        {
            var viewModel = new EditUserViewModel(dbConversation);
            dbConversation.UsingTransaction(() =>
                {
                    viewModel.Element = new UserModel(dbConversation.GetById<User>(userId));
                    viewModel.AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList();
                });
            viewModel.DisplayName = "Edit user...";
            return viewModel;
        }

        EditUserViewModel(IDbConversation dbConversation)
            : base(dbConversation)
        {
        }

        public List<UserRole> AllUserRoles { get; private set; }

        public string Name
        {
            get { return Element.Name; }
            set
            {
                if (value == Element.Name) return;
                Element.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public UserRole UserRole
        {
            get { return Element.UserRole; }
            set
            {
                if (value == Element.UserRole) return;
                Element.UserRole = value;
                NotifyOfPropertyChange(()=>UserRole);
            }
        }
    }
}