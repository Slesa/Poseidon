using System.Collections.ObjectModel;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums.Contracts
{
    public interface IUmsModulesViewModel
    {
        ObservableCollection<IOfficeModule> Modules { get; }
    }
}