using System.Collections.Generic;

namespace Poseidon.BackOffice.Common
{
    public interface IOfficeModule
    {
        string Title { get; }
        string Description { get; }
        string ToolTip { get; }
        string IconFileName { get; }
        int Priority { get; }
        string ViewName { get; set; }
        IOfficeModule Parent { get; }
        IEnumerable<string> Keywords { get; }
    }
}