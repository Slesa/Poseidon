using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        public NavigationViewModel()
        {
            OnBackCommand = new DelegateCommand(OnBack);
            OnForwardCommand = new DelegateCommand(OnForward);
        }


        #region Commands

        public ICommand OnForwardCommand { get; private set; }

        void OnForward()
        {
        }

        public ICommand OnBackCommand { get; private set; }

        void OnBack()
        {
        }

        #endregion

        public string SearchText { get; set; } 
    }
}