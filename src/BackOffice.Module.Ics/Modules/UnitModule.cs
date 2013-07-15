using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class UnitModule : IOfficeModule
    {
        public static readonly string Name = "ICS.UnitModule";

        public UnitModule(IcsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.UnitModule; } }
        public string ToolTip { get { return Strings.UnitModuleTooltip; } }
        public string IconFileName { get { return IcsResources.UnitIcon; } }
        public int Priority { get { return 90; } }
        public IOfficeModule Parent { get ; private set; }
    }
}