using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Modules;

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
            var umsModule = new UmsOfficeModule();
            _container.RegisterType<IOfficeModule, UmsUserModule>(UmsUserModule.Name, new InjectionConstructor(umsModule));
            _container.RegisterType<IOfficeModule, UmsUserRoleModule>(UmsUserRoleModule.Name, new InjectionConstructor(umsModule));
        }
    }
}