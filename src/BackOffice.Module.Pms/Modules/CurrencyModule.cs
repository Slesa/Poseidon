using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class CurrencyModule : IOfficeModule
    {
        public static readonly string Name = "PMS.CurrencyModule";

        public CurrencyModule(PmsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.CurrencyModule; } }
        public string ToolTip { get { return Strings.CurrencyModuleTooltip; } }
        public string IconFileName { get { return PmsResources.CurrencyIcon; } }
        public int Priority { get { return 1; } }
        public IOfficeModule Parent { get ; private set; }
    }
}