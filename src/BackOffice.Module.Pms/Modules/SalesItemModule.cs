using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class SalesItemModule : IOfficeModule
    {
        public static readonly string Name = "PMS.SalesItemModule";

        public SalesItemModule(PmsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.SalesItemModule; } }
        public string ToolTip { get { return Strings.SalesItemModuleTooltip; } }
        public string IconFileName { get { return PmsResources.SalesItemIcon; } }
        public int Priority { get { return 11; } }
        public IOfficeModule Parent { get ; private set; }
    }
}