using System;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UserRoleModule : OfficeModule
    {
        public static readonly string Name = "UserRolesView";

        public UserRoleModule()
        {
            Title = Strings.UserRoleModule;
            Description = Strings.UserRoleModule_Description;
            ToolTip = Strings.UserRoleModule_Tooltip;
            Priority = 2;
            IconFileName = UmsResources.UserRoleIcon;
            TargetUri = new Uri(UmsViews.UserRolesView, UriKind.Relative);
            ParentType = typeof(UmsOfficeModule);
        }
    }
}