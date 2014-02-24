using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using _11_Screens.Framework;

namespace _11_Screens.Shell
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IWorkspace>.Collection.OneActive, IShell
    {
        readonly IDialogManager dialogs;

        [ImportingConstructor]
        public ShellViewModel(IDialogManager dialogs, [ImportMany]IEnumerable<IWorkspace> workspaces) {
            this.dialogs = dialogs;
            Items.AddRange(workspaces);
            CloseStrategy = new ApplicationCloseStrategy();
        }

        public IDialogManager Dialogs {
            get { return dialogs; }
        }
    }
}