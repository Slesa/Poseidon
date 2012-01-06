using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using BackOffice.Contracts;
using Caliburn.Micro;
using Ums.OfficeModule.Resources;

namespace BackOffice 
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        [ImportMany(typeof(IOfficeModule))] 
        IEnumerable<IOfficeModule> _modules;
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            DisplayName = Strings.AppTitle;

            Items.AddRange(_modules);
            ActivateItem(Items.FirstOrDefault());
            var x = this.ActiveItem;
        }
    }
}
