﻿using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Pms.Domain.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class PmsOfficeModule : OfficeModule
    {
        public static readonly string Name = "PMS.PmsModule";

        public PmsOfficeModule()
        {
            Title = Strings.PmsOfficeModule;
            Description = Strings.PmsOfficeModule_Description;
            ToolTip = Strings.PmsOfficeModule_Tooltip;
            IconFileName = PmsResources.PmsIcon;
            Priority = 11;
            //Keywords = Strings.PmsOfficeModule_Keywords.Split(',');
            ViewName = PmsViews.PmsModuleView;
        }
    }
}