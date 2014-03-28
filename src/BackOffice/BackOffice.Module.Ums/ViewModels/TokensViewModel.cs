using System.Collections.ObjectModel;
using System.Windows.Input;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class TokensViewModel : ITokensViewModel
    {
        readonly IDbConversation _dbConversation;

        public TokensViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<Token> Tokens { get; private set; }

        void CreateDatasets()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        Tokens = new ObservableCollection<Token>(_dbConversation.Query(new AllTokensQuery()));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}