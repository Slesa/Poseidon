using System.Collections.Generic;
using System.Collections.ObjectModel;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeUmsModulesViewModel : IUmsModulesViewModel
    {
        public ObservableCollection<IOfficeModule> Modules
        {
            get { return new ObservableCollection<IOfficeModule>(CreateModules()); }
        }

        IEnumerable<IOfficeModule> CreateModules()
        {
            yield return new OfficeModule {Title = "Users", Priority = 1, IconFileName = UmsResources.UserIcon, ToolTip = "User management"};
            yield return new OfficeModule {Title = "User Roles", Priority = 2, IconFileName = UmsResources.UserRoleIcon, ToolTip = "User role management"};
            yield return new OfficeModule {Title = "Tokens", Priority = 2, IconFileName = UmsResources.TokenIcon, ToolTip = "User tokens management"};
        }
    }
}