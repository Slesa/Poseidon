using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace Poseidon.BackOffice.Common.ViewModels
{
    public class ModuleViewModel
    {
        readonly IOfficeModule _module;
        readonly IRegionManager _regionManager;

        public ModuleViewModel(IOfficeModule module, IRegionManager regionManager)
        {
            _module = module;
            _regionManager = regionManager;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return _module.Title; } }
        public string Description { get { return _module.Description; } }
        public string ToolTip { get { return _module.ToolTip; } }
        public string IconFileName { get { return _module.IconFileName; } }
        public Uri TargetUri { get { return _module.TargetUri; } }

        public int Priority { get { return _module.Priority; } }
        public IEnumerable<string> Keywords { get { return _module.Keywords; } }
        public IOfficeModule Parent { get; protected set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            if (TargetUri==null) return;
            _regionManager.RequestNavigate(Regions.TagModulesRegion, TargetUri);
        }
    }
}