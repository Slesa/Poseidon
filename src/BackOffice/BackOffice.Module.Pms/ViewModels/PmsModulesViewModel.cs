using System.Collections.ObjectModel;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Pms.ViewModels
{
    public class PmsModulesViewModel
    {
        public ObservableCollection<IOfficeModule> Modules { get; private set; }
    }
}