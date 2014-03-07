using System;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.BackOffice.Module.Ums.ViewModels;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UmsOfficeModule : OfficeModule
    {
        public UmsOfficeModule()
        {
            Title = Strings.UmsOfficeModule;
            Description = Strings.UserModule_Description;
            ToolTip = Strings.UmsOfficeModule_Tooltip;
            IconFileName = UmsResources.UmsIcon;
            Priority = 1;
            Keywords = Strings.UmsOfficeModule_Keywords.Split(',');
            ViewType = typeof (UmsModulesViewModel);
        }

        public Type ViewType { get; private set; }
    }
    public class UmsOfficeModule2 : OfficeModule
    {
        public UmsOfficeModule2()
        {
            Title = "Ums Module 2";
            Description = "Description 2";
            ToolTip = Strings.UmsOfficeModule_Tooltip;
            IconFileName = UmsResources.UmsIcon;
            Priority = 2;
            Keywords = Strings.UmsOfficeModule_Keywords.Split(',');
            ViewType = typeof (UmsModulesViewModel);
        }

        public Type ViewType { get; private set; }
    }

    public class UserModule : OfficeModule
    {
        public static readonly string Name = "UMS.UserModule";

        public UserModule(UmsOfficeModule parent)
        {
            Title = Strings.UserModule;
            Description = Strings.UserModule_Description;
            ToolTip = Strings.UserModule_Tooltip;
            IconFileName = UmsResources.UserIcon;
            Parent = parent;
        }
    }

    public class UserRoleModule : OfficeModule
    {
        public static readonly string Name = "UMS.UserRoleModule";

        public UserRoleModule(UmsOfficeModule parent)
        {
            Title = Strings.UserRoleModule;
            Description = Strings.UserRoleModule_Description;
            ToolTip = Strings.UserRoleModule_Tooltip;
            IconFileName = UmsResources.UserRoleIcon;
            Parent = parent;
        }
    }

    public class TokenModule : OfficeModule
    {
        public static readonly string Name = "UMS.TokenModule";

        public TokenModule(UmsOfficeModule parent)
        {
            Title = Strings.TokenModule;
            Description = Strings.TokenModule_Description;
            ToolTip = Strings.TokenModule_Tooltip;
            IconFileName = UmsResources.TokenIcon;
            Parent = parent;
        }
    }
}
