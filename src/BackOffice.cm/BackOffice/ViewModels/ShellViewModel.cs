using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using BackOffice.Resources;
using BackOffice.Shared;
using Caliburn.Micro;

namespace BackOffice.ViewModels
{
    // http://karlshifflett.wordpress.com/2009/06/10/wpf-sample-series-listbox-grouping-sorting-subtotals-and-collapsible-regions/
    // http://www.codeproject.com/KB/WPF/WPFOutlookNavi.aspx
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        [ImportMany(typeof(IOfficeModule))]
        IEnumerable<IOfficeModule> _modules;
        public IEnumerable<IOfficeModule> Modules { get { return _modules; } }

        public void OnModuleItemClicked(IModuleItem item)
        {
            Debug.WriteLine("Item clicked " + item.ItemName);
            var view = item.RelatedView;
            if (view!=null)
                ActivateItem(view);
        }

        public override void ActivateItem(IScreen item)
        {
            Debug.WriteLine("Activating "+item.DisplayName);
            base.ActivateItem(item);
            Debug.WriteLine("Activated " + this.ActiveItem.DisplayName);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            DisplayName = AppStrings.AppTitle;
            /*
            foreach (var module in _modules.Where(module => module.ModuleItems != null))
            {
                Items.AddRange(module.ModuleItems);
            }*/
            //ActivateItem(Items.FirstOrDefault());
            //var x = this.ActiveItem;
        }

    }
}
