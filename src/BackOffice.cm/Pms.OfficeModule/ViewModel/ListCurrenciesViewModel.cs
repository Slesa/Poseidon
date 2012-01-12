using System.ComponentModel.Composition;
using Caliburn.Micro;
using Pms.OfficeModule.Resources;

namespace Pms.OfficeModule.ViewModel
{
    [Export(typeof(IPmsModuleItem))]
    public class ListCurrenciesModuleItem : IPmsModuleItem
    {
        [Import(typeof(ListCurrenciesViewModel))]
        ListCurrenciesViewModel _viewModel;

        public string ItemName { get { return Strings.CurrenciesItemName; } }
        public string ToolTip { get { return Strings.CurrenciesItemToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/Currency.png"; } }
        public IScreen RelatedView { get { return _viewModel; } }
        
    }

    [Export(typeof(ListCurrenciesViewModel))]
    public class ListCurrenciesViewModel : Screen
    {
        
    }
}