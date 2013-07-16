using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class PmsOfficeModule : IOfficeModule
    {
        public IRegionManager RegionManager { get; private set; }

        public PmsOfficeModule(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Name { get { return Title; } }
        public string Title { get { return Strings.PmsOfficeModule; } }
        public string ToolTip { get { return Strings.PmsOfficeModuleTooltip; } }
        public string IconFileName { get { return PmsResources.PmsIcon; } }
        public int Priority { get { return Common.Modules.PmsPriority; } }
        public IOfficeModule Parent { get { return null; } }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.ModuleView);
        }
    }
}