using Pms.Business.Contracts;
using Pms.Model;

namespace Pms.Business.Models
{
    public class PmsWorkbench
    {
        public PmsWorkbench(IProvideTable tableProvider)
        {
            TableProvider = tableProvider;
        }

        public IProvideTable TableProvider { get; set; }

        public Waiter Waiter { get; set; }
    }
}