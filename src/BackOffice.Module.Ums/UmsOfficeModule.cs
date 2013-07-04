using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Domain.Ums.Resources;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UmsOfficeModule : IOfficeModule
    {
        public string Title { get { return Strings.UmsOfficeModule; } }
        public string ToolTip { get { return Strings.UmsOfficeModuleTooltip; } }
        public string IconFileName { get { return UmsResources.UmsIcon; } }
        public IOfficeModule Parent { get { return null; } }
    }
}