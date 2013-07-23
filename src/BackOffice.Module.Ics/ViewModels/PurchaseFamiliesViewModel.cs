using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class PurchaseFamiliesViewModel
    {
        readonly IDbConversation _dbConversation;

        public PurchaseFamiliesViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<PurchaseFamily> PurchaseFamilies { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    PurchaseFamilies = new ObservableCollection<PurchaseFamily>(_dbConversation.Query(new AllPurchaseFamiliesQuery()));
                });
        }
    }
}