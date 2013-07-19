using System.Collections.ObjectModel;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class PurchaseItemsViewModel
    {
        public ObservableCollection<PurchaseItem> PurchaseItems { get; set; }
    }
}