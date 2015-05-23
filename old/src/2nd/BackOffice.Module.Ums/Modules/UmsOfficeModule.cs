using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    [SortModule(1)]
    public class UmsOfficeModule : IOfficeModule
    {
        public static readonly string Name = "UMS.OfficeModule";

        public IRegionManager RegionManager { get; private set; }

        public UmsOfficeModule(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.UmsOfficeModule; } }
        public string Description { get; private set; }
        public string ToolTip { get { return Strings.UmsOfficeModuleTooltip; } }
        public string IconFileName { get { return UmsResources.UmsIcon; } }
        public int Priority { get; private set; }
        public IEnumerable<string> Keywords { get; private set; }
        public IEnumerable<IOfficeModule> Children { get; private set; }
        //public int Priority { get { return Common.Modules.UmsPriority; } }
        public IOfficeModule Parent { get { return null; } }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.ModuleView);
        }
    }
}