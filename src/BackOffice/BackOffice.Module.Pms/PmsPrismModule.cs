using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Modules;
using Poseidon.BackOffice.Module.Pms.Views;

namespace Poseidon.BackOffice.Module.Pms
{
    public class PmsPrismModule : IModule
    {
        readonly IUnityContainer _container;

        public PmsPrismModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IOfficeModule, PmsOfficeModule>(PmsOfficeModule.Name, new ContainerControlledLifetimeManager());
            _container.RegisterType<IOfficeModule, DiscountModule>(DiscountModule.Name, new ContainerControlledLifetimeManager());
            /*
                        _container.RegisterType<IOfficeModule, UserRoleModule>(UserRoleModule.Name, new ContainerControlledLifetimeManager());
                        _container.RegisterType<IOfficeModule, TokenModule>(TokenModule.Name, new ContainerControlledLifetimeManager());
            */

/*
            _container.RegisterType<object, UserRolesView>(UmsViews.UserRolesView);
            _container.RegisterType<object, UsersView>(UmsViews.UsersView);
*/
            _container.RegisterType<object, PmsModulesView>(PmsViews.PmsModuleView);

/*
            _container.RegisterType<UserRolesViewModel>();
            _container.RegisterType<UsersViewModel>();
*/
        }
    }
}