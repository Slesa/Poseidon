using System.Collections.Generic;
using System.Linq;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserViewModel
    {
        static public EditUserViewModel CreateViewModel(IDbConversation dbConversation/*, IEventAggregator eventAggregator*/)
        {
            var viewModel = new EditUserViewModel();
            //viewModel.Element = new UserModel();
            //viewModel.DisplayName = "Add new user...";
            dbConversation.UsingTransaction(() =>
                viewModel.AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList());
            return viewModel;
        }

        public string Name { get; set; }
        public UserRole UserRole { get; set; }

        public List<UserRole> AllUserRoles { get; private set; }


        EditUserViewModel()
        {
        }
    }
}