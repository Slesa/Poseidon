using LightCore;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums
{
    public class ModuleRegister : IRegisterModule
    {
        public IContainer Register(IContainer container)
        {
            var builder = new ContainerBuilder();
            builder.Register<IOfficeModule, UmsOfficeModule>();
            container = builder.Build();
            return container;
        }

    }
}