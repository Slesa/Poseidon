using Microsoft.Practices.Prism.Modularity;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Pms
{
    public class RegisterUmsModule : IRegisterModule
    {
        public ModuleInfo GetModuleInfo()
        {
            var pmsModule = typeof(PmsPrismModule);
            return new ModuleInfo
                {
                    ModuleName = pmsModule.Name,
                    ModuleType = pmsModule.AssemblyQualifiedName
                };
        }
    }
}