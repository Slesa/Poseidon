using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using WpfAuthentication.Contracts;

namespace WpfAuthentication.Views
{
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class ViewControl : UserControl, IView
    {
        public ViewControl()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }

        public void Show()
        {
            Visibility = Visibility.Visible;
        }
    }
}
