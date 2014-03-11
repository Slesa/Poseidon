using System.Collections.Generic;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.BackOffice.Core.ViewModels;

namespace Poseidon.BackOffice.Core.Contracts
{
    public interface IModulesViewModel
    {
        IEnumerable<ModuleViewModel> Modules { get; }
    }
}