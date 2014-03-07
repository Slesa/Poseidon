using System.Collections.Generic;
using Poseidon.BackOffice.Common;

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
        public IOfficeModule Parent { get; protected set; }

        public void ActivateCommand()
        {
        }
    }

/*
    public class OfficeModuleViewModel : ModuleViewModel
    {
        public OfficeModuleViewModel(IOfficeModule module)
            : base(module)
        {
        }
    }
*/
}