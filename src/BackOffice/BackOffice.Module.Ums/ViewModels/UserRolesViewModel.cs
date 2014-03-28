using System.Collections.ObjectModel;
using System.Windows.Input;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UserRolesViewModel : IUserRolesViewModel
    {
        readonly IDbConversation _dbConversation;

        public UserRolesViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<UserRole> UserRoles { get; private set; }

        void CreateDatasets()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        UserRoles = new ObservableCollection<UserRole>(_dbConversation.Query(new AllUserRolesQuery()));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}