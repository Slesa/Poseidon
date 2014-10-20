using System.Collections.ObjectModel;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.BackOffice.Module.Pms.ViewModels
{
    public class WaitersViewModel
    {
        public ObservableCollection<Waiter> Waiters { get; set; }
    }
}