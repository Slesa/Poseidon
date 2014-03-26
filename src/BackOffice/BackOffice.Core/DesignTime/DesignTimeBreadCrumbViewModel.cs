using System.Collections.Generic;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.BackOffice.Core.ViewModels;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeBreadCrumbViewModel
    {
        public IEnumerable<ModuleViewModel> CurrentModules
        {
            get
            {
                var umsModule = new OfficeModule
                    {
                        Title = "User Module",
                        Description = "This is the user management module.",
                        IconFileName = "/Poseidon.BackOffice.Core;component/DesignTime/Resources/Ums.png",
                    };
                yield return new ModuleViewModel(umsModule, null);
                var userModule = new OfficeModule
                    {
                        Title = "Users",
                        Description = "Manage all users",
                        IconFileName = "/Poseidon.BackOffice.Core;component/DesignTime/Resources/User.png",
                        //Parent = umsModule,
                    };
                yield return new ModuleViewModel(userModule, null);
            }
        }
    }
}