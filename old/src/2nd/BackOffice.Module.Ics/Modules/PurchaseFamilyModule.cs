using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class PurchaseFamilyModule : IOfficeModule
    {
        public static readonly string Name = "ICS.PurchaseFamilyModule";

        public IRegionManager RegionManager { get; private set; }

        public PurchaseFamilyModule(IcsOfficeModule parent, IRegionManager regionManager)
        {
            Parent = parent;
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.PurchaseFamilyModule; } }
        public string ToolTip { get { return Strings.PurchaseFamilyModuleTooltip; } }
        public string IconFileName { get { return IcsResources.PurchaseFamilyIcon; } }
        public int Priority { get { return 50; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.PurchaseFamiliesView);
        }
    }
}