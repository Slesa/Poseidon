using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UmsModule : IModule
    {
        readonly IUnityContainer _container;

        public UmsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IOfficeModule, UmsOfficeModule>(Modules.UmsModule);
        }
    }
}