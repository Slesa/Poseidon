using Pms.Business.Contracts;
using Pms.Model;

namespace Pms.Business.Models
{
    public class PmsTerminal
    {
        public PmsTerminal(IProvideWorkbenches workbenchProvider)
        {
            WorkbenchProvider = workbenchProvider;
        }

        public IProvideWorkbenches WorkbenchProvider { get; private set; }

        public Terminal Terminal { get; set; }
    }
}