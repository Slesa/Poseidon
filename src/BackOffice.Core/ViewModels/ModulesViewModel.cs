using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesView
    {
        readonly IEventAggregator _eventAggregator;

        public IEnumerable<IOfficeModule> Modules { get; private set; }

        public ModulesViewModel(IEventAggregator eventAggregator, IUnityContainer container)
        {
            _eventAggregator = eventAggregator;
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules;
        }
    }
}