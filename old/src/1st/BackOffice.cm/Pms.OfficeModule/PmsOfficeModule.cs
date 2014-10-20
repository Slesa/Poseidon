using System.Collections.Generic;
using System.ComponentModel.Composition;
using BackOffice.Shared;
using Pms.OfficeModule.Resources;

namespace Pms.OfficeModule
{
    [Export(typeof(IOfficeModule))]
    public class PmsOfficeModule : IOfficeModule
    {
        public string ModuleName { get { return Strings.PmsOfficeModule; } }
        public string ToolTip { get { return Strings.PmsOfficeModuleToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/Pms.png"; } }

        [ImportMany(typeof(IPmsModuleItem))]
        IEnumerable<IModuleItem> _items;
        public IEnumerable<IModuleItem> ModuleItems { get { return _items; } }
    }
}
