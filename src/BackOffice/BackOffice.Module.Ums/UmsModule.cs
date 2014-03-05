using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.ViewModels;
using Poseidon.BackOffice.Module.Ums.Views;

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
            _container.RegisterType<IOfficeModule, UmsOfficeModule>("UmsofficeModule"); // new ContainerControlledLifetimeManager());

            //_container.RegisterType<IOfficeModule, UserModule>(UserModule.Name);
            //_container.RegisterType<IOfficeModule, UserRoleModule>(UserRoleModule.Name);

            _container.RegisterType<object, UserRolesView>("UserRolesView");
            _container.RegisterType<object, UsersView>("UsersView");
            _container.RegisterType<object, UmsModulesView>("UmsModulesView");

            _container.RegisterType<UserRolesViewModel>();
            _container.RegisterType<UsersViewModel>();
        }
         
    }
}