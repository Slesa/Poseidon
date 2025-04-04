using System.Collections.Generic;
using Caliburn.Micro;

namespace BackOffice.Shared
{
    public interface IModuleItem
    {
        string ItemName { get; }
        string IconFileName { get; }
        string ToolTip { get; }
        IEnumerable<string> Keywords { get; }
        IScreen RelatedView { get; }
    }

    public interface IOfficeModule
    {
        string ModuleName { get; }
        string IconFileName { get; }
        string ToolTip { get; }
        IEnumerable<IModuleItem> ModuleItems { get; }
    }
}
