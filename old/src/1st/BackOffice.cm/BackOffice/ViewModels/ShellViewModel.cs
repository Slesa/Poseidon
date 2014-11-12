using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using BackOffice.Resources;
using BackOffice.Shared;
using BackOffice.Shared.Events;
using Caliburn.Micro;

namespace BackOffice.ViewModels
{
    // http://karlshifflett.wordpress.com/2009/06/10/wpf-sample-series-listbox-grouping-sorting-subtotals-and-collapsible-regions/
    // http://www.codeproject.com/KB/WPF/WPFOutlookNavi.aspx
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell, IHandle<ActivateScreenEvent>
    {
        [ImportMany(typeof(IOfficeModule))]
        IEnumerable<IOfficeModule> _modules;
        public IEnumerable<IOfficeModule> Modules { get { return _modules; } }

        public IEventAggregator EventAggregator { get; set; }
        public IWindowManager WindowManager { get; set; }

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            EventAggregator = eventAggregator;
            WindowManager = windowManager;
            EventAggregator.Subscribe(this);
        }

        public void OnModuleItemClicked(IModuleItem item)
        {
            Debug.WriteLine("Item clicked " + item.ItemName);
            var view = item.RelatedView;
            if (view!=null)
                ActivateItem(view);
        }

        public override void ActivateItem(IScreen screen)
        {
            Debug.WriteLine("Activating "+screen.DisplayName);
            base.ActivateItem(screen);
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

        public void Handle(ActivateScreenEvent message)
        {
            //WindowManager.ShowDialog(message.Screen);
            message.Screen.Deactivated += (obj, args) =>
                {
                    var screen = message.Screen;
                    if (screen!=null) Items.Remove(screen);
                };
            ActivateItem(message.Screen);
        }
        /*
        void Screen_Deactivated(object sender, DeactivationEventArgs e)
        {
            e.
        }*/
    }
}
