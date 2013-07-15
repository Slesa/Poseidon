using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class IcsOfficeModule : IOfficeModule
    {
        public string Name { get { return Title; } }
        public string Title { get { return Strings.IcsOfficeModule; } }
        public string ToolTip { get { return Strings.IcsOfficeModuleTooltip; } }
        public string IconFileName { get { return IcsResources.IcsIcon; } }
        public int Priority { get { return Common.Modules.IcsPriority; } }
        public IOfficeModule Parent { get { return null; } }
    }
}