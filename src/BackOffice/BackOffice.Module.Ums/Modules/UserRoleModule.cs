﻿using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UserRoleModule : OfficeModule
    {
        public static readonly string Name = "UMS.UserRoleModule";

        public UserRoleModule()
        {
            Title = Strings.UserRoleModule;
            Description = Strings.UserRoleModule_Description;
            ToolTip = Strings.UserRoleModule_Tooltip;
            Priority = 2;
            IconFileName = UmsResources.UserRoleIcon;
            ViewName = UmsViews.UserRolesView;
            ParentType = typeof(UmsOfficeModule);
        }
    }
}