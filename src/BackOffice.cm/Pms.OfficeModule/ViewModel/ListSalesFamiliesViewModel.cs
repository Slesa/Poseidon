using System.ComponentModel.Composition;
using Caliburn.Micro;
using Pms.OfficeModule.Resources;

namespace Pms.OfficeModule.ViewModel
{
    [Export(typeof(IPmsModuleItem))]
    public class ListSalesFamiliesModuleItem : IPmsModuleItem
    {
        [Import(typeof(ListSalesFamiliesViewModel))]
        ListSalesFamiliesViewModel _viewModel;

        public string ItemName { get { return Strings.SalesFamiliesItemName; } }
        public string ToolTip { get { return Strings.SalesFamiliesItemToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/SalesFamily.png"; } }
        public IScreen RelatedView { get { return _viewModel; } }
        
    }

    [Export(typeof(ListSalesFamiliesViewModel))]
    public class ListSalesFamiliesViewModel : Screen
    {
        
    }
}