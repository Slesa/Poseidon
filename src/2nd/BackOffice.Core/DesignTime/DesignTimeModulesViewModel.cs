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
            public string Description { get; private set; }
            public string ToolTip { get; private set; }
            public string IconFileName { get; private set; }
            public int Priority { get; private set; }
            public IEnumerable<string> Keywords { get; private set; }
            public IEnumerable<IOfficeModule> Children { get; private set; }
            public IOfficeModule Parent { get; private set; }
            public OfficeModule(int priority, string title, string toolTip, string icon, IOfficeModule parent=null)
            {
                Priority = priority;
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
            var root = new OfficeModule(0, "Backoffice", "This is the root", "");
            Modules = new List<IOfficeModule>
                {
                     new OfficeModule(1, "User Management", "Manage user, user rights and user groups", @"pack://application:,,,/Poseidon.Domain.Ums.Resources;component/Ums.png", root),
                     new OfficeModule(2, "POS Management", "Define your POS environment", @"pack://application:,,,/Poseidon.Domain.Pms.Resources;component/Pms.png", root),
                     new OfficeModule(3, "Customer Relationship", "Know your customers", @"pack://application:,,,/Poseidon.Domain.Crm.Resources;component/Crm.png", root),
                     new OfficeModule(4, "Inventory Control", "Know your inventory", @"pack://application:,,,/Poseidon.Domain.Ics.Resources;component/Ics.png", root),
                };
        }
    }
}