using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Poseidon.BackOffice.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel()
        {
            OnQuitCommand = new DelegateCommand(OnQuit);
            OnBackCommand = new DelegateCommand(OnBack);
        }

        #region Commands

        public ICommand OnQuitCommand { get; private set; }

        void OnQuit()
        {
            Application.Current.Shutdown();
        }

        public ICommand OnBackCommand { get; private set; }

        void OnBack()
        {
        }

        #endregion
    }
}