using System.Windows;
using ViewSwitchingNavigation.Infrastructure;

namespace ViewSwitchingNavigation
{
    public partial class ShellView : Window, IShell
    {
        public ShellView()
        {
            InitializeComponent();
        }
    }
}
