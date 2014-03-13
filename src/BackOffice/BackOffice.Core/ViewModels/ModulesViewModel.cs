using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesViewModel
    {
        public ModulesViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            var modules = container.ResolveAll<IOfficeModule>().ToArray();
            Modules = modules.Where(x=>x.ParentType==null).OrderBy(x=>x.Priority).Select(x => new OfficeModuleViewModel(x, modules, regionManager));
        }

        public IEnumerable<ModuleViewModel> Modules { get; private set; }

    }
}