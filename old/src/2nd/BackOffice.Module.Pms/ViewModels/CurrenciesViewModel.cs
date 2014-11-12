using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Hibernate.Queries;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.BackOffice.Module.Pms.ViewModels
{
    public class CurrenciesViewModel
    {
        readonly IDbConversation _dbConversation;

        public CurrenciesViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<Currency> Currencies { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    Currencies = new ObservableCollection<Currency>(_dbConversation.Query(new AllCurrenciesQuery()));
                });
        }
    }
}