using System.Collections.Generic;

namespace Poseidon.BackOffice.Common
{
    public interface IOfficeModule
    {
        string Title { get; }
        string ToolTip { get; }
        string IconFileName { get; }

        int Priority { get; }
        IEnumerable<string> Keywords { get; }
    }
}