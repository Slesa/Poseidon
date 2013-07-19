using System.Collections.ObjectModel;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class ProductionItemsViewModel
    {
        public ObservableCollection<ProductionItem> ProductionItems { get; set; }         
    }
}