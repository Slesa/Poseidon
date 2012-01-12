using System.ComponentModel.Composition;
using Caliburn.Micro;
using Pms.OfficeModule.Resources;

namespace Pms.OfficeModule.ViewModel
{
    [Export(typeof(IPmsModuleItem))]
    public class ListSalesModuleItem : IPmsModuleItem
    {
        [Import(typeof(ListSalesItemsViewModel))]
        ListSalesItemsViewModel _viewModel;

        public string ItemName { get { return Strings.SalesItemsItemName; } }
        public string ToolTip { get { return Strings.SalesItemsItemToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/SalesItem.png"; } }
        public IScreen RelatedView { get { return _viewModel; } }
        
    }

    [Export(typeof(ListSalesItemsViewModel))]
    public class ListSalesItemsViewModel : Screen
    {
    }
}