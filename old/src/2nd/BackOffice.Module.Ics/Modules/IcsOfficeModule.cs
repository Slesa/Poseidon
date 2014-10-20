using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class IcsOfficeModule : IOfficeModule
    {
        public IRegionManager RegionManager { get; private set; }

        public IcsOfficeModule(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Name { get { return Title; } }
        public string Title { get { return Strings.IcsOfficeModule; } }
        public string ToolTip { get { return Strings.IcsOfficeModuleTooltip; } }
        public string IconFileName { get { return IcsResources.IcsIcon; } }
        public int Priority { get { return Common.Modules.IcsPriority; } }
        public IOfficeModule Parent { get { return null; } }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.ModuleView);
        }
    }
}