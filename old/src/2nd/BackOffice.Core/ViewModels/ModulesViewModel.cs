// ok
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesView
    {
        public IEnumerable<IOfficeModule> Modules { get; private set; }

        public ModulesViewModel(IUnityContainer container)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules;
        }
    }
}