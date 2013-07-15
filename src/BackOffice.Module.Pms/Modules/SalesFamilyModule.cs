using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class SalesFamilyModule : IOfficeModule
    {
        public static readonly string Name = "PMS.SalesFamilyModule";

        public SalesFamilyModule(PmsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.SalesFamilyModule; } }
        public string ToolTip { get { return Strings.SalesFamilyModuleTooltip; } }
        public string IconFileName { get { return PmsResources.SalesFamilyIcon; } }
        public int Priority { get { return 10; } }
        public IOfficeModule Parent { get ; private set; }
    }
}