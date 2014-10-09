using System;
using System.Windows;
using WpfAuthentication.Model;
using WpfAuthentication.Services;
using WpfAuthentication.ViewModels;
using WpfAuthentication.Views;

namespace WpfAuthentication
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);

            var viewModel = new AuthenticationViewModel(new AuthenticationService());
            var loginWindow = new LoginWindow(viewModel);
            loginWindow.Show();
        }
    }
}
