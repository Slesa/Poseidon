using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace ViewSwitchingNavigation.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel()
        {
            OnQuitCommand = new DelegateCommand(OnQuit);
        }

        #region Commands

        public ICommand OnQuitCommand { get; private set; }

        void OnQuit()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}