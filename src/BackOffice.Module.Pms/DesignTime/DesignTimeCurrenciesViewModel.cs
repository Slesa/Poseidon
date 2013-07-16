using System.Collections.ObjectModel;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.BackOffice.Module.Pms.DesignTime
{
    public class DesignTimeCurrenciesViewModel
    {
        public ObservableCollection<Currency> Currencies { get; private set; }

        public DesignTimeCurrenciesViewModel()
        {

            Currencies = new ObservableCollection<Currency>()
                             {
                                 new Currency {Name = "Euro"},
                                 new Currency {Name = "Dollar"},
                             };
        }
    }
}