using System;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UserModule : OfficeModule
    {
        public static readonly string Name = "UsersView";

        public UserModule()
        {
            Title = Strings.UserModule;
            Description = Strings.UserModule_Description;
            ToolTip = Strings.UserModule_Tooltip;
            Priority = 1;
            IconFileName = UmsResources.UserIcon;
            TargetUri = new Uri(UmsViews.UsersView, UriKind.Relative);
            ParentType = typeof(UmsOfficeModule);
        }
    }
}