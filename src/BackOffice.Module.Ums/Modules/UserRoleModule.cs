using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Domain.Ums.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UserRoleModule : IOfficeModule
    {
        public static readonly string Name = "UMS.UserRoleModule";

        IRegionManager _regionManager;

        public UserRoleModule(UmsOfficeModule parent, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Parent = parent;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.UserRoleModule; } }
        public string ToolTip { get { return Strings.UserRoleModuleTooltip; } }
        public string IconFileName { get { return UmsResources.UserRoleIcon; } }
        public int Priority { get { return 2; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            _regionManager.RequestNavigate(Regions.TagModulesRegion, View.UserRolesView);
        }
    }
}