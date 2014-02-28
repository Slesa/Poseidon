using LightCore;

namespace Poseidon.BackOffice.Common
{
    public interface IRegisterModule
    {
        void Register(IContainerBuilder builder);
    }
}