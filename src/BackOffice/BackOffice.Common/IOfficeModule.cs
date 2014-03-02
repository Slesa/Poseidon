using System;
using System.Collections.Generic;
using Caliburn.Micro;

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
        Type ViewType { get; }
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

        public IEnumerable<IOfficeModule> Children { get; set; }
        public Type ViewType { get; set; }
    }
}