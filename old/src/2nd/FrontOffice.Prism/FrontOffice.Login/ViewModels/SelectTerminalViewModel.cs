using System.Collections.Generic;
using System.Diagnostics;

namespace FrontOffice.Login.ViewModels
{
    public class SelectTerminalViewModel
    {
        public IEnumerable<string> Terminals { get; private set; }

        public SelectTerminalViewModel()
        {
            InitializeTerminals();
        }

        [Conditional("DEBUG")]
        void InitializeTerminals()
        {

        }
    }
}