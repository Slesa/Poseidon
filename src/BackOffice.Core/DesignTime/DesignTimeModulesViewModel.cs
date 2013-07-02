using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeModulesViewModel : IModulesView
    {
        class OfficeModule : IOfficeModule
        {
            public string Title { get; private set; }
            public string ToolTip { get; private set; }
            public string IconFileName { get; private set; }
            public IOfficeModule Parent { get; private set; }
            public OfficeModule(string title, string toolTip, string icon, IOfficeModule parent=null)
            {
                Title = title;
                ToolTip = toolTip;
                IconFileName = icon;
                Parent = parent;
            }
        }

        [Dependency]
        public IEnumerable<IOfficeModule> Modules { get; set; }

        public DesignTimeModulesViewModel()
        {
            Modules = new List<IOfficeModule>()
                {
                     new OfficeModule("User Management", "Manage user, user rights and user groups", @"/Poseidon.Domain.Ums.Resources;component/Ums.png"),
                     new OfficeModule("POS Management", "Define your POS environment", @"/Poseidon.Domain.Pms.Resources;component/Pms.png"),
                };
        }
    }
}