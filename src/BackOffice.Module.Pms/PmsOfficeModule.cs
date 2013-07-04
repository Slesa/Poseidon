using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms
{
    public class PmsOfficeModule : IOfficeModule
    {
        public string Title { get { return Strings.PmsOfficeModule; } }
        public string ToolTip { get { return Strings.PmsOfficeModuleTooltip; } }
        public string IconFileName { get { return PmsResources.PmsIcon; } }
        public IOfficeModule Parent { get { return null; } }
    }
}