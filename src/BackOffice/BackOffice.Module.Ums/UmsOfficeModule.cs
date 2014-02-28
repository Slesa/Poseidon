using System.Collections.Generic;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UmsOfficeModule : IOfficeModule
    {
        public string Title { get; private set; }
        public string ToolTip { get; private set; }
        public string IconFileName { get; private set; }
        public IOfficeModule Parent { get; private set; }
        public int Priority { get; private set; }
        public IEnumerable<string> Keywords { get; private set; }
    }
}