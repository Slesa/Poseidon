﻿using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Domain.Pms.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class WaiterTeamModule : IOfficeModule
    {
        public static readonly string Name = "PMS.WaiterTeamModule";

        public IRegionManager RegionManager { get; private set; }

        public WaiterTeamModule(PmsOfficeModule parent, IRegionManager regionManager)
        {
            Parent = parent;
            RegionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return Strings.WaiterTeamModule; } }
        public string ToolTip { get { return Strings.WaiterTeamModuleTooltip; } }
        public string IconFileName { get { return PmsResources.WaiterTeamIcon; } }
        public int Priority { get { return 1; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            RegionManager.RequestNavigate(Regions.TagModulesRegion, View.WaiterTeamsView);
        }
    }
}