using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ums.Hibernate.Queries;
using Poseidon.Domain.Ums.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UserRolesViewModel
    {
        readonly IDbConversation _dbConversation;

        public UserRolesViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<UserRole> UserRoles { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    UserRoles = new ObservableCollection<UserRole>(_dbConversation.Query(new AllUserRolesQuery()));
                });
        }
    }
}