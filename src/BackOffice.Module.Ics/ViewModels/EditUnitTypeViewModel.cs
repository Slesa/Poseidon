using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using NHibernate;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Common.Persistence;
using Poseidon.Common.Prism;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class EditUnitTypeViewModel : NotificationObject
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;
        readonly IEventAggregator _eventAggregator;
        UnitType _unitType = new UnitType();

        public EditUnitTypeViewModel(IDbConversation dbConversation, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        public string Name
        {
            get { return _unitType.Name; }
            set
            {
                if (_unitType.Name == value) return;
                _unitType.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        #region Commands

        public ICommand SaveCommand { get; private set; }

        void OnSave()
        {
            try
            {
                _dbConversation.UsingTransaction(()=>_dbConversation.Insert(_unitType));
            }
            catch (StaleObjectStateException)
            {
                MessageBox.Show("Object was changed outside this dialog."); //Strings.Error_PurchaseItems_CannotSave);
                //return true;
            }
            catch(Exception ex )
            {
                _eventAggregator.GetEvent<ShowMessageEvent>().Publish(ex.Message);
                //return false;
            }
        }

        bool CanSave()
        {
            return true;
        }

        public ICommand CancelCommand { get; private set; }

        void OnCancel()
        {
            _eventAggregator.GetEvent<ClearMessageEvent>().Publish(0);

            var region = _regionManager.Regions[Regions.TagModulesRegion];
            region.Remove(region.ActiveViews.First());
        }

        #endregion
    }
}