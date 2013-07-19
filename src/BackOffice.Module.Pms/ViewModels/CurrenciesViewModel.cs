using System.Collections.ObjectModel;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.BackOffice.Module.Pms.ViewModels
{
    public class CurrenciesViewModel
    {
        public ObservableCollection<Currency> Currencies { get; set; }
    }
}