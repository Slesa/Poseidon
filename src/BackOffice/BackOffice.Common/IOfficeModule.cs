using System;
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
        Uri TargetUri { get; }
        Type ParentType { get; }
        IEnumerable<string> Keywords { get; }
    }
}