using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesViewModel
    {
        public IEnumerable<ModuleViewModel> Modules { get; set; }

        public ModulesViewModel(IUnityContainer container)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules.Select(x => new OfficeModuleViewModel(x));
        }

    }
}