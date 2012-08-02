using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BackOffice.Shared.ViewModels;
using Caliburn.Micro;
using Persistence.Shared;
using Ums.Model;
using Ums.NHibernate.Queries;
using Ums.OfficeModule.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class EditUserViewModel : EditItemViewModel<UserModel>, IDataErrorInfo
    {
        static public EditUserViewModel CreateViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            var viewModel = new EditUserViewModel();
            viewModel.Element = new UserModel();
            viewModel.DisplayName = "Add new user...";
            dbConversation.UsingTransaction(()=>
                viewModel.AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList());
            return viewModel;
        }

        static public EditUserViewModel CreateViewModel(int userId, IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            var viewModel = new EditUserViewModel();
            dbConversation.UsingTransaction(() =>
                {
                    viewModel.Element = new UserModel(dbConversation.GetById<User>(userId));
                    viewModel.AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList();
                });
            viewModel.DisplayName = "Edit user...";
            return viewModel;
        }

        EditUserViewModel()
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

        public void Save()
        {
            if (!SuccessfullySaved(() => DbConversation.Insert(Element.User)))
                return;
            EventAggregator.Publish(new UserChangedEvent(Element.User));
            TryClose();
        }
    }
}