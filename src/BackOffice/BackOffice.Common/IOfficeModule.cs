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
        IEnumerable<string> Keywords { get; }
        IEnumerable<IOfficeModule> Children { get; }
    }

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

        IEnumerable<IOfficeModule> _children;
        public IEnumerable<IOfficeModule> Children { get { return _children ?? (_children = new List<IOfficeModule>()); }}
    }
}