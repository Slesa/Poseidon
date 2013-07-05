using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Pms
{
    public class PmsModule : IModule
    {
        readonly IUnityContainer _container;

        public PmsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IOfficeModule,PmsOfficeModule>(Modules.PmsModule);
        }
    }
}