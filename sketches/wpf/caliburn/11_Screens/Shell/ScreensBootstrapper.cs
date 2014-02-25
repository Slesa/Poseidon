using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using _11_Screens.Customers;
using _11_Screens.Framework;
using _11_Screens.Orders;

namespace _11_Screens.Shell 
{
    public class ScreensBootstrapper : BootstrapperBase
    {
        CompositionContainer _container;
        Window mainWindow;
        bool actuallyClosing;

        public ScreensBootstrapper()
        {
            Start();
        }

        protected override void Configure()
        {
            _container = new CompositionContainer(
                new AggregateCatalog(
                    AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                    )
                );

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue<Func<IMessageBox>>(() => _container.GetExportedValue<IMessageBox>());
            batch.AddExportedValue<Func<CustomerViewModel>>(() => _container.GetExportedValue<CustomerViewModel>());
            batch.AddExportedValue<Func<OrderViewModel>>(() => _container.GetExportedValue<OrderViewModel>());
            batch.AddExportedValue(_container);

            _container.Compose(batch);

        }

        protected override object GetInstance(Type serviceType, string key)
        {
            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            var result = exports.FirstOrDefault();
            if (result != null) return result;

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            var result = _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
            return result;
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
            mainWindow = Application.MainWindow;
            //mainWindow.Closing += MainWindowClosing;
        }

        void MainWindowClosing(object sender, CancelEventArgs e)
        {
            if (actuallyClosing)
                return;

            e.Cancel = true;

            Execute.OnUIThread(() =>
                {
                    var shell = IoC.Get<IShell>();

                    shell.CanClose(result =>
                        {
                            if (result)
                            {
                                actuallyClosing = true;
                                mainWindow.Close();
                            }
                        });
                });
        }
    }
}
