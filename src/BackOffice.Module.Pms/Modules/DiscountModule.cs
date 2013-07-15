using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class DiscountModule : IOfficeModule
    {
        public static readonly string Name = "PMS.DiscountModule";

        public DiscountModule(PmsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.DiscountModule; } }
        public string ToolTip { get { return Strings.DiscountModuleTooltip; } }
        public string IconFileName { get { return PmsResources.DiscountIcon; } }
        public int Priority { get { return 2; } }
        public IOfficeModule Parent { get ; private set; }
    }
}