using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class DiscountModule : OfficeModule
    {
        public static readonly string Name = "PMS.DiscountModule";

        public IRegionManager RegionManager { get; private set; }

        public DiscountModule(PmsOfficeModule parent, IRegionManager regionManager)
        {
            Parent = parent;
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.DiscountModule; } }
        public string ToolTip { get { return Strings.DiscountModuleTooltip; } }
        public string IconFileName { get { return PmsResources.DiscountIcon; } }
        public int Priority { get { return 2; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.DiscountsView);
        }
    }
}