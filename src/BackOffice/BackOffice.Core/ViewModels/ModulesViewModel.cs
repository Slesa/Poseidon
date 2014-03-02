using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using LightCore;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;
using Poseidon.BackOffice.Core.ViewModels;

namespace Poseidon.BackOffice.Core
{
    public class ModulesViewModel : Screen, IModulesViewModel
    {
        public ModulesViewModel(IContainer container, IEventAggregator eventAggregator)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules.Select(x => new OfficeModuleViewModel(x, eventAggregator));
        }

        public IEnumerable<ModuleViewModel> Modules { get; private set; }
    }
}