using System.Collections.Generic;
using System.Linq;
using LightCore;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModuleViewModel
    {
        readonly IOfficeModule _module;

        public ModuleViewModel(IOfficeModule module)
        {
            _module = module;
        }

        public string Title { get { return _module.Title; } }
        public string Description { get { return _module.Description; } }
        public string ToolTip { get { return _module.ToolTip; } }
        public string IconFileName { get { return _module.IconFileName; } }

        public int Priority { get { return _module.Priority; } }
        public IEnumerable<string> Keywords { get { return _module.Keywords; } }
        public IEnumerable<IOfficeModule> Children { get { return _module.Children; } }

        public void Activate()
        {
            System.Diagnostics.Debug.WriteLine("Activate "+Title);
        }
    }

    public class ModulesViewModel : IModulesViewModel
    {
        public ModulesViewModel(IContainer container)
        {
            var modules = container.ResolveAll<IOfficeModule>();
            Modules = modules.Select(x => new ModuleViewModel(x));
        }

        public IEnumerable<ModuleViewModel> Modules { get; private set; }
    }
}