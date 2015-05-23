// ok
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeStatusBarViewModel : IStatusBarViewModel
    {
        public string Message { get { return "This is a message"; } } 
    }
}