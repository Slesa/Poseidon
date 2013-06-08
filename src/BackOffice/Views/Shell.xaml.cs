using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Poseidon.BackOffice.ViewModels;

namespace Poseidon.BackOffice.Views
{
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = ServiceLocator.Current.GetInstance<ShellViewModel>();
            }
        }
    }
}
