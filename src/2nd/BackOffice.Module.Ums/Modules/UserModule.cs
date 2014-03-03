using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UserModule : IOfficeModule
    {
        public static readonly string Name = "UMS.UserModule";

        public IRegionManager RegionManager { get; private set; }

        public UserModule(UmsOfficeModule parent, IRegionManager regionManager)
        {
            RegionManager = regionManager;
            Parent = parent;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.UserModule; } }
        public string Description { get; private set; }
        public string ToolTip { get { return Strings.UserModuleTooltip; } }
        public string IconFileName { get { return UmsResources.UserIcon; } }
        public int Priority { get { return 1; } }
        public IEnumerable<string> Keywords { get; private set; }
        public IEnumerable<IOfficeModule> Children { get; private set; }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.UsersView);
        }
    }
}