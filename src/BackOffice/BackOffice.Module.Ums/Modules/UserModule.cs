using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UserModule : OfficeModule
    {
        public static readonly string Name = "UMS.UserModule";

        public UserModule()
        {
            Title = Strings.UserModule;
            Description = Strings.UserModule_Description;
            ToolTip = Strings.UserModule_Tooltip;
            IconFileName = UmsResources.UserIcon;
            ViewName = UmsViews.UsersView;
            ParentType = typeof(UmsOfficeModule);
        }
    }
}