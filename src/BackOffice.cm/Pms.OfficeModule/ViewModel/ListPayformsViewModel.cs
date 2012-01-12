using System.ComponentModel.Composition;
using Caliburn.Micro;
using Pms.OfficeModule.Resources;

namespace Pms.OfficeModule.ViewModel
{
    [Export(typeof(IPmsModuleItem))]
    public class ListPayformsModuleItem : IPmsModuleItem
    {
        [Import(typeof(ListPayformsViewModel))]
        ListPayformsViewModel _viewModel;

        public string ItemName { get { return Strings.PayformsItemName; } }
        public string ToolTip { get { return Strings.PayformsItemToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/Payform.png"; } }
        public IScreen RelatedView { get { return _viewModel; } }
        
    }

    [Export(typeof(ListPayformsViewModel))]
    public class ListPayformsViewModel : Screen
    {
        public string ItemName { get { return Strings.PayformsItemName; } }
        public string ToolTip { get { return Strings.PayformsItemToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/Payform.png"; } }
       
    }
}