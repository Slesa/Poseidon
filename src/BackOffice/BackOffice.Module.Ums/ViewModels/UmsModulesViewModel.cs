using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.BackOffice.Module.Ums.Modules;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UmsModulesViewModel
    {
        public UmsModulesViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules.Where(x=>x.ParentType==typeof (UmsOfficeModule)).OrderBy(x=>x.Priority).Select(x => new ModuleViewModel(x, /*modules,*/ regionManager));
        }

        public IEnumerable<ModuleViewModel> Modules { get; private set; }
    }
}