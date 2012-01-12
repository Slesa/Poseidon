using System.Collections.Generic;
using System.ComponentModel.Composition;
using BackOffice.Contracts;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule
{
    [Export(typeof(IOfficeModule))]
    public class UmsOfficeModule : IOfficeModule
    {

        public string ModuleName { get { return Strings.UmsOfficeModule; } }
        public string ToolTip { get { return Strings.UmsOfficeModuleToolTip; } }
        public string IconFileName { get { return @"/Ums.Resources;component/Ums.png"; } }

        [ImportMany(typeof(IUmsModuleItem))]
        IEnumerable<IUmsModuleItem> _items;
        public IEnumerable<IModuleItem> ModuleItems { get { return _items; } }
        
    }

}