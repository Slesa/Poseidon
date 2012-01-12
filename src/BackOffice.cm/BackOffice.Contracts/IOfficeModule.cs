using System.Collections.Generic;
using Caliburn.Micro;

namespace BackOffice.Contracts
{
    public interface IModuleItem
    {
        string ItemName { get; }
        string IconFileName { get; }
        string ToolTip { get; }
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
