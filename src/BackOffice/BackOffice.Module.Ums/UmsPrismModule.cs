using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Modules;
using Poseidon.BackOffice.Module.Ums.ViewModels;
using Poseidon.BackOffice.Module.Ums.Views;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UmsPrismModule : IModule
    {
        readonly IUnityContainer _container;

        public UmsPrismModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<UmsOfficeModule, UmsOfficeModule>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IOfficeModule, UserModule>(UserModule.Name);
            _container.RegisterType<IOfficeModule, UserRoleModule>(UserRoleModule.Name);
            _container.RegisterType<IOfficeModule, TokenModule>(TokenModule.Name);

            _container.RegisterType<object, UserRolesView>(UmsViews.UserRolesView);
            _container.RegisterType<object, UsersView>(UmsViews.UsersView);
            _container.RegisterType<object, UmsModulesView>(UmsViews.ModuleView);

            _container.RegisterType<UserRolesViewModel>();
            _container.RegisterType<UsersViewModel>();
        }
         
    }
}