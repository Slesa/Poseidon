using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Castle.MicroKernel.Registration;
using log4net.Repository.Hierarchy;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;
using PrismContrib.WindsorExtensions;

namespace Backoffice
{
    public class Bootstrapper : WindsorBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
#if SILVERLIGHT
            Application.Current.RootVisual = (UIElement) Shell;
#else
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.Show();
#endif
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //RegisterTypeIfMissing(typeof(Shell), typeof(Shell), true);
            Container.Register(GetShellRegistrations().ToArray());
        }

        static IEnumerable<IRegistration> GetShellRegistrations()
        {
            yield return Component.For<Shell>().ImplementedBy<Shell>();
            yield return Component.For<ILoggerFacade>().ImplementedBy<Log4NetLogger>();
        }
    }
}