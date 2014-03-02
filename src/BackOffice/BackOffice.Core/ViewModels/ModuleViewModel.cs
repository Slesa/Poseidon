using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Events;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModuleViewModel
    {
        readonly IOfficeModule _module;
        readonly IEventAggregator _eventAggregator;

        public ModuleViewModel(IOfficeModule module, IEventAggregator eventAggregator)
        {
            _module = module;
            _eventAggregator = eventAggregator;
        }

        public string Title { get { return _module.Title; } }
        public string Description { get { return _module.Description; } }
        public string ToolTip { get { return _module.ToolTip; } }
        public string IconFileName { get { return _module.IconFileName; } }

        public int Priority { get { return _module.Priority; } }
        public IEnumerable<string> Keywords { get { return _module.Keywords; } }
        public IEnumerable<ModuleViewModel> Children { get; protected set; }

        public void ActivateCommand()
        {
            _eventAggregator.Publish(new StatusBarMessageEvent("Activating "+ _module.Title));
            _eventAggregator.Publish(new ActivateScreenEvent(_module.ViewType));
        }
    }

    public class OfficeModuleViewModel : ModuleViewModel
    {
        public OfficeModuleViewModel(IOfficeModule module, IEventAggregator eventAggregator)
            : base(module, eventAggregator)
        {
            if (module.Children != null) Children = module.Children.Select(x => new ModuleViewModel(x, eventAggregator));
        }
    }
}