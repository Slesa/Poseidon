using System.Collections.ObjectModel;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UmsModulesViewModel
    {
        public ObservableCollection<IOfficeModule> Modules { get; private set; }
    }
}