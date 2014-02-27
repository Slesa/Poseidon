using System.Collections.Generic;

namespace Poseidon.BackOffice.Common
{
    public interface IOfficeModule
    {
        string Title { get; }
        string ToolTip { get; }
        string IconFileName { get; }

        IOfficeModule Parent { get; }
        int Priority { get; }
        IEnumerable<string> Keywords { get; }
    }

    public class OfficeModule : IOfficeModule
    {
        public OfficeModule()
        {
            Keywords = new List<string>();
        }

        public string Title { get; set; }
        public string ToolTip { get; set; }
        public string IconFileName { get; set; }
        public IOfficeModule Parent { get; set; }
        public int Priority { get; set; }
        public IEnumerable<string> Keywords { get; private set; }
    }
}