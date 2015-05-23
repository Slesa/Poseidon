using System.Collections.ObjectModel;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.BackOffice.Module.Pms.ViewModels
{
    public class DiscountsViewModel
    {
        public ObservableCollection<Discount> Discounts { get; set; }
    }
}