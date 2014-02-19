using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class ProductionItemModule : IOfficeModule
    {
        public static readonly string Name = "ICS.ProductionFamilyModule";

        public IRegionManager RegionManager { get; private set; }

        public ProductionItemModule(IcsOfficeModule parent, IRegionManager regionManager)
        {
            Parent = parent;
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.ProductionItemModule; } }
        public string ToolTip { get { return Strings.ProductionItemModuleTooltip; } }
        public string IconFileName { get { return IcsResources.ProductionItemIcon; } }
        public int Priority { get { return 30; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.ProductionItemsView);
        }
    }
}