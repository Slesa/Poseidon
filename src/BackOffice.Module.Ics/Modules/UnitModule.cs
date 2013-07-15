using Poseidon.BackOffice.Common;
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

        public string Title { get { return "Units"; } }
        public string ToolTip { get { return "Manage your units"; } }
        public string IconFileName { get { return IcsResources.UnitIcon; } }
        public int Priority { get { return 90; } }
        public IOfficeModule Parent { get ; private set; }
    }
}