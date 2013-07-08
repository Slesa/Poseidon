using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.Domain.Ums.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UmsUserRoleModule : IOfficeModule
    {
        public static readonly string Name = "UMS.UserRoleModule";

        public IRegionManager RegionManager { get; private set; }

        public UmsUserRoleModule(UmsOfficeModule parent, IRegionManager regionManager)
        {
            RegionManager = regionManager;
            Parent = parent;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return "User roles"; } }
        public string ToolTip { get { return "Manage your user roles"; } }
        public string IconFileName { get { return UmsResources.UserRoleIcon; } }
        public int Priority { get { return 2; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, new Uri("UmsModuleView", UriKind.Relative));
        }
    }
}