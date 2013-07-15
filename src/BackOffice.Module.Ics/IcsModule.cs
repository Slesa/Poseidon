using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Modules;

namespace Poseidon.BackOffice.Module.Ics
{
    public class IcsModule : IModule
    {
        readonly IUnityContainer _container;

        public IcsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IcsOfficeModule>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IOfficeModule,UnitModule>(UnitModule.Name);
            _container.RegisterType<IOfficeModule,UnitTypeModule>(UnitTypeModule.Name);
        }
    }
}