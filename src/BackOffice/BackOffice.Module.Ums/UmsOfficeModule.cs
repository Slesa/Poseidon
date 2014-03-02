using System;
using System.Collections.Generic;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UmsOfficeModule : IOfficeModule
    {
        public UmsOfficeModule()
        {
            Title = Strings.UmsOfficeModule;
            Description = Strings.UserModule_Description;
            ToolTip = Strings.UmsOfficeModule_Tooltip;
            IconFileName = UmsResources.UmsIcon;
            Priority = 1;
            Keywords = Strings.UmsOfficeModule_Keywords.Split(',');
            Children = CreateChildren();
            ViewType = typeof(UmsModulesViewModel);
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ToolTip { get; private set; }
        public string IconFileName { get; private set; }
        public IOfficeModule Parent { get { return null; } }
        public int Priority { get; private set; }
        public IEnumerable<string> Keywords { get; private set; }
        public IEnumerable<IOfficeModule> Children { get; private set; }
        public Type ViewType { get; private set; }

        IEnumerable<IOfficeModule> CreateChildren()
        {
            yield return new OfficeModule
                {
                    Title = Strings.UserModule,
                    Description = Strings.UserModule_Description,
                    ToolTip = Strings.UserModule_Tooltip,
                    IconFileName = UmsResources.UserIcon,
                };

            yield return new OfficeModule
                {
                    Title = Strings.UserRoleModule,
                    Description = Strings.UserRoleModule_Description,
                    ToolTip = Strings.UserRoleModule_Tooltip,
                    IconFileName = UmsResources.UserRoleIcon,
                };
            yield return new OfficeModule
                {
                    Title = Strings.TokenModule,
                    Description = Strings.TokenModule_Description,
                    ToolTip = Strings.TokenModule_Tooltip,
                    IconFileName = UmsResources.TokenIcon,
                };
        }
    }
}