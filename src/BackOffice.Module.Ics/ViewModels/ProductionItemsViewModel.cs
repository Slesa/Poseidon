using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class ProductionItemsViewModel
    {
        readonly IDbConversation _dbConversation;

        public ProductionItemsViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<ProductionItem> ProductionItems { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    ProductionItems = new ObservableCollection<ProductionItem>(_dbConversation.Query(new AllProductionItemsQuery()));
                });
        }
    }
}