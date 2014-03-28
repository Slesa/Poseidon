using System.Collections.ObjectModel;
using System.Windows.Input;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel : IUsersViewModel
    {
        readonly IDbConversation _dbConversation;

        public UsersViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<User> Users { get; private set; }

        void CreateDatasets()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        Users = new ObservableCollection<User>(_dbConversation.Query(new AllUsersQuery()));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}