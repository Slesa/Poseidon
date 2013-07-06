using Poseidon.BackOffice.Common;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class CurrencyModule : IOfficeModule
    {
        public static readonly string Name = "PMS.CurrencyModule";

        public CurrencyModule(IOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return "Currencies"; } }
        public string ToolTip { get { return "Manage your currencies"; } }
        public string IconFileName { get { return PmsResources.CurrencyIcon; } }
        public int Priority { get { return 1; } }
        public IOfficeModule Parent { get ; private set; }
    }
}