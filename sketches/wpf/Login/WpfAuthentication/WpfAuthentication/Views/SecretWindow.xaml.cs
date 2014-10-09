using System.Security.Permissions;
using System.Windows;
using WpfAuthentication.Contracts;

namespace WpfAuthentication.Views
{
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class SecretWindow : Window, IView
    {
        public SecretWindow()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
    }
}
