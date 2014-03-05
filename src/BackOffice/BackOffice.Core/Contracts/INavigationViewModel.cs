using System.Windows.Input;

namespace Poseidon.BackOffice.Core.Contracts
{
    public interface INavigationViewModel
    {
        string SearchText { get; set; }

        ICommand OnHomeCommand { get; }
        ICommand OnForwardCommand { get; }
        ICommand OnBackCommand { get; } 
    }
}