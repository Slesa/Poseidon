using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class PurchaseItemModule : IOfficeModule
    {
        public static readonly string Name = "ICS.PurchaseItemModule";

        public IRegionManager RegionManager { get; private set; }

        public PurchaseItemModule(IcsOfficeModule parent, IRegionManager regionManager)
        {
            Parent = parent;
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.PurchaseItemModule; } }
        public string ToolTip { get { return Strings.PurchaseItemModuleTooltip; } }
        public string IconFileName { get { return IcsResources.PurchaseItemIcon; } }
        public int Priority { get { return 40; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.PurchaseItemsView);
        }
    }
}