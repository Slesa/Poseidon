using System.Windows;
using Caliburn.Micro;

namespace Poseidon.BackOffice.ViewModels
{
    public class ShellViewModel : Screen, IShell
    {
        public ShellViewModel()
        {
            DisplayName = "Poseidon BackOffice";
        }

        #region Commands
        
        public void DoQuit()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}