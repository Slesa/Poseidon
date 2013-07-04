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
            Modules = new List<IOfficeModule>
                {
                     new OfficeModule("User Management", "Manage user, user rights and user groups", @"pack://application:,,,/Poseidon.Domain.Ums.Resources;component/Ums.png"),
                     new OfficeModule("POS Management", "Define your POS environment", @"pack://application:,,,/Poseidon.Domain.Pms.Resources;component/Pms.png"),
                     new OfficeModule("Customer Relationship", "Know your customers", @"pack://application:,,,/Poseidon.Domain.Crm.Resources;component/Crm.png"),
                     new OfficeModule("Inventory Control", "Know your inventory", @"pack://application:,,,/Poseidon.Domain.Ics.Resources;component/Ics.png"),
                };
        }
    }
}