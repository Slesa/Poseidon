using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class StockModule : IOfficeModule
    {
        public static readonly string Name = "ICS.StockModule";

        public StockModule(IcsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.StockModule; } }
        public string ToolTip { get { return Strings.StockModuleTooltip; } }
        public string IconFileName { get { return IcsResources.StockIcon; } }
        public int Priority { get { return 90; } }
        public IOfficeModule Parent { get ; private set; }
    }
}