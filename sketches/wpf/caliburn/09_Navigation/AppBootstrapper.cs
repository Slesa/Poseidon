using Caliburn.Micro;

namespace _09_Navigation
{
    using System.Windows;

    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Start();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}