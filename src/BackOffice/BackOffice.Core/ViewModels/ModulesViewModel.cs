using System.Collections.Generic;
using System.Linq;
using LightCore;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesViewModel
    {
        public ModulesViewModel(IContainer container)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules.Select(x => new OfficeModuleViewModel(x));
        }

        public IEnumerable<ModuleViewModel> Modules { get; private set; }
    }
}