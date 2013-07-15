using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Domain.Ums.Resources;

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
        public string ToolTip { get { return Strings.UserModuleTooltip; } }
        public string IconFileName { get { return UmsResources.UserIcon; } }
        public int Priority { get { return 1; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.UsersView);
        }
    }
}