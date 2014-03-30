using Poseidon.Common.Persistence.Contracts;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserRoleViewModel
    {
        static public EditUserRoleViewModel CreateViewModel(IDbConversation dbConversation/*, IEventAggregator eventAggregator*/)
        {
            var viewModel = new EditUserRoleViewModel();
            //viewModel.Element = new UserModel();
            //viewModel.DisplayName = "Add new user...";
            //dbConversation.UsingTransaction(() =>
            //    viewModel.AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList());
            return viewModel;
        }

        public string Name { get; set; }

        EditUserRoleViewModel()
        {
        }
    }
}