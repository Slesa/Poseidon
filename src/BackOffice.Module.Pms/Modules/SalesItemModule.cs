using Poseidon.BackOffice.Common;
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

        public string Title { get { return "Sales items"; } }
        public string ToolTip { get { return "Manage your sales items"; } }
        public string IconFileName { get { return PmsResources.SalesItemIcon; } }
        public int Priority { get { return 11; } }
        public IOfficeModule Parent { get ; private set; }
    }
}