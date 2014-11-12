using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class StocksViewModel
    {
        readonly IDbConversation _dbConversation;

        public StocksViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<Stock> Stocks { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    Stocks = new ObservableCollection<Stock>(_dbConversation.Query(new AllStocksQuery()));
                });
        }
    }
}