using System.Collections.Generic;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.BackOffice.Core.ViewModels;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeModulesViewModel
    {
        class UmsOfficeModule : OfficeModule
        {
            
        }

        IEnumerable<ModuleViewModel> _modules;

        public IEnumerable<ModuleViewModel> ModulesCollection
        {
            get { return _modules ?? (_modules = CreateModules()); }
        }

        IEnumerable<ModuleViewModel> CreateModules()
        {
            var umsModule = new UmsOfficeModule
                {
                    Title = "Office Module 1",
                    Description = "This is the Office module number one.",
                    IconFileName = "/Poseidon.BackOffice.Core;component/DesignTime/Resources/Ums.png",
                };
            yield return new OfficeModuleViewModel(umsModule, CreateUmsChildren(umsModule), null);
        }

        IEnumerable<OfficeModule> CreateUmsChildren(IOfficeModule umsModule)
        {
            var userModule = new OfficeModule
                {
                    Title = "Users",
                    Description = "Manage all users",
                    IconFileName = "/Poseidon.BackOffice.Core;component/DesignTime/Resources/User.png",
                    ParentType = typeof(UmsOfficeModule),
                };
            yield return userModule;
            var userRoleModule = new OfficeModule
                {
                    Title = "User Roles",
                    Description = "Manage all user roles",
                    IconFileName = "/Poseidon.BackOffice.Core;component/DesignTime/Resources/UserRole.png",
                    ParentType = typeof(UmsOfficeModule),
                };
            yield return userRoleModule;
            var tokenModule = new OfficeModule
                {
                    Title = "Tokens",
                    Description = "Manage all tokens",
                    IconFileName = "/Poseidon.BackOffice.Core;component/DesignTime/Resources/Token.png",
                    ParentType = typeof(UmsOfficeModule),
                };
            yield return tokenModule;
        }
    }
}