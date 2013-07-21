using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class EditUnitTypeViewModel
    {
        readonly IRegionManager _regionManager;

        public EditUnitTypeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        #region Commands

        public ICommand SaveCommand { get; private set; }

        void OnSave()
        {
        }

        bool CanSave()
        {
            return false;
        }

        public ICommand CancelCommand { get; private set; }

        void OnCancel()
        {
            var region = _regionManager.Regions[Regions.TagModulesRegion];
            region.Remove(this);
        }

        #endregion
    }
}