using System.Security.Permissions;
using System.Windows;
using WpfAuthentication.Contracts;

namespace WpfAuthentication.Views
{
    [PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
    public partial class AdminWindow : Window, IView
    {
        public AdminWindow()
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
