using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Pms.Resources;
using Poseidon.Pms.Domain.Resources;

namespace Poseidon.BackOffice.Module.Pms.Modules
{
    public class DiscountModule : OfficeModule
    {
        public static readonly string Name = "PMS.DiscountModule";

        public DiscountModule()
        {
            Title = Strings.DiscountModule;
            Description = Strings.DiscountModule_Description;
            ToolTip = Strings.DiscountModule_Tooltip;
            Priority = 1;
            IconFileName = PmsResources.DiscountIcon;
            //ViewName = PmsViews.DiscountsView;
            ParentType = typeof(PmsOfficeModule);
        }
    }
}