using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesViewModel
    {
        public IEnumerable<ModuleViewModel> Modules { get; set; }

        public ModulesViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules.Select(x => new ModuleViewModel(x, regionManager));
        }

    }
}