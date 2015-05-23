using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class PurchaseItemsViewModel
    {
        readonly IDbConversation _dbConversation;

        public PurchaseItemsViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<PurchaseItem> PurchaseItems { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    PurchaseItems = new ObservableCollection<PurchaseItem>(_dbConversation.Query(new AllPurchaseItemsQuery()));
                });
        }
    }
}