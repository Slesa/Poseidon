using Microsoft.Practices.Prism.Modularity;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums
{
    public class RegisterUmsModule : IRegisterModule
    {
        public ModuleInfo GetModuleInfo()
        {
            var umsModule = typeof(UmsModule);
            return new ModuleInfo
                {
                    ModuleName = umsModule.Name,
                    ModuleType = umsModule.AssemblyQualifiedName
                };
        }
    }
}