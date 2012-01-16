using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using Persistence.Shared;
using Persistence.Shared.Configuration;

namespace BackOffice
{
    public class AppBootstrapper : Bootstrapper<IShell>
    {
        CompositionContainer _container;

        /// <summary>
        /// By default, we are configured to use MEF
        /// </summary>
        protected override void Configure()
        {
            PreloadAssemblies();

            var catalog = new AggregateCatalog(
                AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                );
            //catalog.Catalogs.Add(new DirectoryCatalog(".", "*.OfficeModule.dll"));

            _container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            //batch.AddExportedValue<IPersistenceConfiguration>(
            //    new SqlServerPersistenceConfiguration(ConfigurationManager.AppSettings["DbConnection"]));
            batch.AddExportedValue(_container);
            batch.AddExportedValue(catalog);

            _container.ComposeExportedValue("ConnectionString", ConfigurationManager.AppSettings["DbConnection"]);
            _container.Compose(batch);

            LogManager.GetLog = type => new AppLogger(type);
        }

        static IEnumerable<string> GetAssemblies()
        {
            yield return "Persistence.Shared.dll";

            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var dllPath in Directory.GetFiles(directoryPath, "*.NHibernate.dll"))
                yield return dllPath;
            foreach (var dllPath in Directory.GetFiles(directoryPath, "*.OfficeModule.dll"))
                yield return dllPath;
        }

        static void PreloadAssemblies()
        {
            foreach(var assembly in GetAssemblies())
                PreloadAssembly(assembly);
        }

        static void PreloadAssembly(string fileName)
        {
            try
            {
                var assembly = Assembly.LoadFrom(fileName);
                AssemblySource.Instance.Add(assembly);
            }
            catch (BadImageFormatException ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return;
            }
            catch (FileNotFoundException ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return;
            }
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Count() > 0)
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }
    }
}
