using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using StateBasedNavigation.Model;
using StateBasedNavigation.ViewModels;
using StateBasedNavigation.Views;

namespace StateBasedNavigation
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypeIfMissing(typeof(IChatService), typeof(ChatService), true);
            RegisterTypeIfMissing(typeof(ChatViewModel), typeof(ChatViewModel), true);
        }
    }
}