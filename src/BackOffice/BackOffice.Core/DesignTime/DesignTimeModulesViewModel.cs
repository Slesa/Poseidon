using System.Collections.Generic;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;
using Poseidon.BackOffice.Core.ViewModels;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeModulesViewModel : IModulesViewModel
    {
        IEnumerable<ModuleViewModel> _modules;

        public IEnumerable<ModuleViewModel> Modules
        {
            get { return _modules ?? (_modules = CreateModules()); }
        }

        IEnumerable<ModuleViewModel> CreateModules()
        {
            yield return new ModuleViewModel(new OfficeModule
                {
                    Title = "Office Module 1", 
                    Description = "This is the Office module number one.",
                    IconFileName = "/Poseidon.Ums.Domain.Resources;component/Ums.png"
                });
        }
    }
}