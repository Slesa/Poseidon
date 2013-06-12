using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel
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
            Application.Current.Shutdown();
        }

        public ICommand OnBackCommand { get; private set; }

        void OnBack()
        {
        }

        #endregion

        public string SearchText { get; set; } 
    }
}