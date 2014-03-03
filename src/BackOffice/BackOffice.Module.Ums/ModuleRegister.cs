using LightCore;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums
{
    public class ModuleRegister : IRegisterModule
    {
        public void Register(IContainerBuilder builder)
        {
            builder.Register<IOfficeModule, UmsOfficeModule>();
            builder.Register<UmsModulesView>();
            builder.Register<UmsModulesViewModel>();
        }
    }
}