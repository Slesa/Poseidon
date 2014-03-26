using Microsoft.Practices.Prism.Modularity;

namespace Poseidon.BackOffice.Common
{
    public interface IRegisterModule
    {
        ModuleInfo GetModuleInfo();
    }
}