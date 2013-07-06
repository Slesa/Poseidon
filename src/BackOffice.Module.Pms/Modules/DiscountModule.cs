using Poseidon.BackOffice.Common;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class DiscountModule : IOfficeModule
    {
        public static readonly string Name = "PMS.DiscountModule";

        public DiscountModule(IOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return "Discounts"; } }
        public string ToolTip { get { return "Manage your discounts"; } }
        public string IconFileName { get { return PmsResources.DiscountIcon; } }
        public int Priority { get { return 2; } }
        public IOfficeModule Parent { get ; private set; }
    }
}