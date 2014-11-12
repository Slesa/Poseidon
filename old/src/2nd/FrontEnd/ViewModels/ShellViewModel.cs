using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Poseidon.FrontEnd.Resources;

namespace Poseidon.FrontEnd.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel()
        {
            OnQuitCommand = new DelegateCommand(OnQuit);
        }

        public string Version
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return string.Format(Strings.Version, fvi.ProductVersion);
            }
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