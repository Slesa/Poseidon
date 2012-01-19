using System.ComponentModel;
using BackOffice.Shared.ViewModels;
using Caliburn.Micro;
using Persistence.Shared;
using Ums.Model;
using Ums.OfficeModule.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class EditUserRoleViewModel : EditItemViewModel<UserRoleModel>, IDataErrorInfo
    {
        static public EditUserRoleViewModel CreateViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            var viewModel = new EditUserRoleViewModel(dbConversation, eventAggregator);
            viewModel.Element = new UserRoleModel();
            viewModel.DisplayName = "Add new user role...";
            return viewModel;
        }

        static public EditUserRoleViewModel CreateViewModel(int userRoleId, IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            var viewModel = new EditUserRoleViewModel(dbConversation, eventAggregator);
            dbConversation.UsingTransaction(()=>
                viewModel.Element = new UserRoleModel(dbConversation.GetById<UserRole>(userRoleId)));
            viewModel.DisplayName = "Edit user role";
            return viewModel;
        }

        EditUserRoleViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator) 
            : base(dbConversation, eventAggregator)
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

        public void Save()
        {
            if (!SuccessfullySaved(() => DbConversation.Insert(Element.UserRole)))
                return;
            EventAggregator.Publish(new UserRoleChangedEvent(Element.UserRole));
            TryClose();
        }
    }
}