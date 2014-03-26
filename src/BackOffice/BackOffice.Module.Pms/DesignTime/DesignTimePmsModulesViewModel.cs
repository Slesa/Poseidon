using System.Collections.Generic;
using System.Collections.ObjectModel;
using Poseidon.BackOffice.Common;
using Poseidon.Pms.Domain.Resources;

namespace Poseidon.BackOffice.Module.Pms.DesignTime
{
    public class DesignTimeUmsModulesViewModel
    {
        public ObservableCollection<IOfficeModule> Modules
        {
            get { return new ObservableCollection<IOfficeModule>(CreateModules()); }
        }

        IEnumerable<IOfficeModule> CreateModules()
        {
            yield return new OfficeModule {Title = "Discounts", Priority = 1, IconFileName = PmsResources.DiscountIcon, ToolTip = "Manage your discounts"};
            yield return new OfficeModule {Title = "Payforms", Priority = 2, IconFileName = PmsResources.PayformIcon, ToolTip = "Manage your forms of payment"};
            yield return new OfficeModule {Title = "Sales family groups", Priority = 2, IconFileName = PmsResources.SalesFamilyGroupIcon, ToolTip = "Group your sales families into family groups"};
        }
    }
}