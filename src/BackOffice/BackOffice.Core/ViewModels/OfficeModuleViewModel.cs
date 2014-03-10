using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class OfficeModuleViewModel : ModuleViewModel
    {
        public OfficeModuleViewModel(IOfficeModule module, IEnumerable<IOfficeModule> modules, IRegionManager regionManager)
            : base(module, regionManager)
        {
            Children = modules.Where(x => x.ParentType == module.GetType()).Select(x => new ModuleViewModel(x, regionManager));
        }

        public IEnumerable<ModuleViewModel> Children { get; private set; }

    }
}