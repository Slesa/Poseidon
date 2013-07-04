using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesView
    {
        readonly IEventAggregator _eventAggregator;

        //[Dependency]
        public IEnumerable<IOfficeModule> Modules { get; private set; }

        public ModulesViewModel(IEventAggregator eventAggregator, IOfficeModule[] modules)
        {
            _eventAggregator = eventAggregator;
            Modules = modules;
        }

    }
}