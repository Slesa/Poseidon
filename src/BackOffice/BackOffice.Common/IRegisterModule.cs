using LightCore;

namespace Poseidon.BackOffice.Common
{
    public interface IRegisterModule
    {
        IContainer Register(IContainer container);
    }
}