using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Pms.OfficeModule.Resources;

namespace Pms.OfficeModule.ViewModel
{
    [Export(typeof(IPmsModuleItem))]
    public class ListDiscountsModuleItem : IPmsModuleItem
    {
        [Import(typeof(ListDiscountsViewModel))]
        ListDiscountsViewModel _viewModel;

        public string ItemName { get { return Strings.DiscountsItemName; } }
        public string ToolTip { get { return Strings.DiscountsItemToolTip; } }
        public string IconFileName { get { return @"/Pms.Resources;component/Discount.png"; } }
        public IEnumerable<string> Keywords
        {
            get
            {
                yield return Strings.KeyDiscounts;
                yield return Strings.KeyDiscount;
            }
        }
        public IScreen RelatedView { get { return _viewModel; } }
       
    }

    [Export(typeof(ListDiscountsViewModel))]
    public class ListDiscountsViewModel : Screen
    {
        
    }
}