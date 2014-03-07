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
}
