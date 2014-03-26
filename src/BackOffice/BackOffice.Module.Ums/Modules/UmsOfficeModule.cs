using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UmsOfficeModule : OfficeModule
    {
        public static readonly string Name = "UMS.UmsModule";

        public UmsOfficeModule()
        {
            Title = Strings.UmsOfficeModule;
            Description = Strings.UserModule_Description;
            ToolTip = Strings.UmsOfficeModule_Tooltip;
            IconFileName = UmsResources.UmsIcon;
            Priority = 1;
            Keywords = Strings.UmsOfficeModule_Keywords.Split(',');
            ViewName = UmsViews.UmsModuleView;
        }
    }
}
