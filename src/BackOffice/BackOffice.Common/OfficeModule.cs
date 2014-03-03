using System.Collections.Generic;

namespace Poseidon.BackOffice.Common
{
    public class OfficeModule : IOfficeModule
    {
        public OfficeModule()
        {
            Keywords = new List<string>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ToolTip { get; set; }
        public string IconFileName { get; set; }
        public int Priority { get; set; }
        public IEnumerable<string> Keywords { get; private set; }
        public IEnumerable<IOfficeModule> Children { get; set; }
    }
}