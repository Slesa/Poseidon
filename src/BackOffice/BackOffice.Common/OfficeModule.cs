using System.Collections.Generic;

namespace Poseidon.BackOffice.Common
{
    public class OfficeModule : IOfficeModule
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ToolTip { get; set; }
        public string IconFileName { get; set; }
        public int Priority { get; set; }
        public string ViewName { get; set; }
        public IOfficeModule Parent { get; set; }

        IEnumerable<string> _keywords;

        public IEnumerable<string> Keywords
        {
            get { return _keywords ?? (_keywords = new List<string>()); } 
            protected set { _keywords = value; }
        }
    }
}