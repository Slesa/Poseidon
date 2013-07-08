using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Modules;
using Poseidon.BackOffice.Module.Ums.ViewModels;

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
            _container.RegisterType<UmsOfficeModule>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IOfficeModule, UmsUserModule>(UmsUserModule.Name);
            _container.RegisterType<IOfficeModule, UmsUserRoleModule>(UmsUserRoleModule.Name);

            _container.RegisterType<UserRolesViewModel>();
            _container.RegisterType<UsersViewModel>();
        }
    }
}