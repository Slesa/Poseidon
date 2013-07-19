using System.Collections.ObjectModel;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.BackOffice.Module.Pms.ViewModels
{
    public class SalesItemsViewModel
    {
        public ObservableCollection<SalesItem> SalesItems { get; set; }
    }
}