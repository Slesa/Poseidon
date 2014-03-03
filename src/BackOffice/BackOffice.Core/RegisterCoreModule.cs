using Microsoft.Practices.Prism.Modularity;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Core
{
    public class RegisterCoreModule : IRegisterModule
    {
        public ModuleInfo GetModuleInfo()
        {
            var coreModule = typeof(CoreModule);
            return new ModuleInfo
                {
                    ModuleName = coreModule.Name,
                    ModuleType = coreModule.AssemblyQualifiedName
                };
        }
    }
}