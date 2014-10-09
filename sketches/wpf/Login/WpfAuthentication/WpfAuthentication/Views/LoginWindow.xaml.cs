using System.Windows;
using WpfAuthentication.Contracts;
using WpfAuthentication.ViewModels;

namespace WpfAuthentication.Views
{
    public partial class LoginWindow : Window, IView
    {
        public LoginWindow(AuthenticationViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
    }
}
