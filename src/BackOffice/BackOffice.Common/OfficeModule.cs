using System;
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
        public Uri TargetUri { get; set; }
        public Type ParentType { get; set; }

        IEnumerable<string> _keywords;

        public IEnumerable<string> Keywords
        {
            get { return _keywords ?? (_keywords = new List<string>()); } 
            protected set { _keywords = value; }
        }
    }
}