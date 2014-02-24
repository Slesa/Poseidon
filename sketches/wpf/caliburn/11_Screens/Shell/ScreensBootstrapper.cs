﻿using System.ComponentModel;
using Caliburn.Micro;
using _11_Screens.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows;
using _11_Screens.Framework;
using _11_Screens.Orders;

namespace _11_Screens
{
    public class ScreensBootstrapper : BootstrapperBase
    {
        CompositionContainer container;
        Window mainWindow;
        bool actuallyClosing;

        public ScreensBootstrapper()
        {
            Start();
        }

        protected override void Configure() {
            container = new CompositionContainer(
                new AggregateCatalog(
                    AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                    )
                );

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue<Func<IMessageBox>>(() => container.GetExportedValue<IMessageBox>());
            batch.AddExportedValue<Func<CustomerViewModel>>(() => container.GetExportedValue<CustomerViewModel>());
            batch.AddExportedValue<Func<OrderViewModel>>(() => container.GetExportedValue<OrderViewModel>());
            batch.AddExportedValue(container);

            container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key) {
            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            if(exports.Any())
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType) {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance) {
            container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<IShell>();

            mainWindow = Application.MainWindow;
            mainWindow.Closing += MainWindowClosing;
        }

        void MainWindowClosing(object sender, CancelEventArgs e) {
            if (actuallyClosing)
                return;

            e.Cancel = true;

            Execute.OnUIThread(() => {
                var shell = IoC.Get<IShell>();

                shell.CanClose(result => {
                    if(result) {
                        actuallyClosing = true;
                        mainWindow.Close();
                    }
                });
            });
        }
    }
}