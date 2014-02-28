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
            Description = Strings.UserModuleDescription;
            ToolTip = Strings.UmsOfficeModuleTooltip;
            IconFileName = UmsResources.UmsIcon;
            Priority = 1;
            Keywords = Strings.UmsOfficeModuleKeywords.Split(',');
            Children = CreateChildren();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ToolTip { get; private set; }
        public string IconFileName { get; private set; }
        public IOfficeModule Parent { get { return null; } }
        public int Priority { get; private set; }
        public IEnumerable<string> Keywords { get; private set; }
        public IEnumerable<IOfficeModule> Children { get; private set; }

        IEnumerable<IOfficeModule> CreateChildren()
        {
            yield return new OfficeModule {Title = "Module 1", Description = "Some description about module 1"};
        }
    }
}