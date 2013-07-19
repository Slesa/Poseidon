using System.Collections.ObjectModel;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class StocksViewModel
    {
        public ObservableCollection<Stock> Stocks { get; set; }
    }
}