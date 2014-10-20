using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class SalesFamilyModule : IOfficeModule
    {
        public static readonly string Name = "PMS.SalesFamilyModule";

        public IRegionManager RegionManager { get; private set; }

        public SalesFamilyModule(PmsOfficeModule parent, IRegionManager regionManager)
        {
            Parent = parent;
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.SalesFamilyModule; } }
        public string ToolTip { get { return Strings.SalesFamilyModuleTooltip; } }
        public string IconFileName { get { return PmsResources.SalesFamilyIcon; } }
        public int Priority { get { return 10; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.SalesFamiliesView);
        }
    }
}