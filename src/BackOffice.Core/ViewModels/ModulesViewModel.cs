using Microsoft.Practices.Prism.Events;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IModulesView
    {
        readonly IEventAggregator _eventAggregator;

        public ModulesViewModel(IEventAggregator eventAggregator)
         {
             _eventAggregator = eventAggregator;
         }
    }
}