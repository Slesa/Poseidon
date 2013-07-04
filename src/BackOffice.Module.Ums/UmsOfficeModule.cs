using BackOffice.Module.Ums.Resources;
using Poseidon.BackOffice.Common;
using Poseidon.Domain.Ums.Resources;

namespace BackOffice.Module.Ums
{
    [Priority(1)]
    public class UmsOfficeModule : IOfficeModule
    {
        public string Title { get { return Strings.UmsOfficeModule; } }
        public string ToolTip { get { return Strings.UmsOfficeModuleTooltip; } }
        public string IconFileName { get { return UmsResources.UmsIcon; } }
        public IOfficeModule Parent { get { return null; } }
    }
}