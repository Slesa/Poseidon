using System.Windows.Input;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeNavigationViewModel : INavigationViewModel
    {
        public string SearchText { get; set; }
        public ICommand OnHomeCommand { get; private set; }
        public ICommand OnForwardCommand { get; private set; }
        public ICommand OnBackCommand { get; private set; }
    }
}