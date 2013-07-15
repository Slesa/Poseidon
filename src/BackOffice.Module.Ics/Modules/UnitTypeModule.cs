using Poseidon.BackOffice.Common;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class UnitTypeModule : IOfficeModule
    {
        public static readonly string Name = "ICS.UnitTypeModule";

        public UnitTypeModule(IcsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return "Unit types"; } }
        public string ToolTip { get { return "Manage your unit types"; } }
        public string IconFileName { get { return IcsResources.UnitTypeIcon; } }
        public int Priority { get { return 100; } }
        public IOfficeModule Parent { get ; private set; }
    }
}