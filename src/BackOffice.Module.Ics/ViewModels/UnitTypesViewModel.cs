using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class UnitTypesViewModel
    {
        public UnitTypesViewModel()
        {
            NewUnitTypeCommand = new DelegateCommand(OnNewUnitType);
            EditUnitTypeCommand = new DelegateCommand(OnEditUnitType, CanEditUnitType);
            DelUnitTypeCommand = new DelegateCommand(OnDelUnitType, CanDelUnitType);
        }

        public ObservableCollection<UnitType> UnitTypes { get; set; }

        public ICommand NewUnitTypeCommand { get; set; }

        void OnNewUnitType()
        {
        }

        public ICommand EditUnitTypeCommand { get; set; }

        void OnEditUnitType()
        {
        }

        bool CanEditUnitType()
        {
            return true;
        }

        public ICommand DelUnitTypeCommand { get; set; }

        void OnDelUnitType()
        {
        }

        bool CanDelUnitType()
        {
            return true;
        }
    }
}