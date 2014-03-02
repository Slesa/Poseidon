using System.Collections.ObjectModel;
using Caliburn.Micro;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ums
{
    public class UmsModulesViewModel : Screen
    {
        public ObservableCollection<IOfficeModule> Modules { get; private set; }
    }
}