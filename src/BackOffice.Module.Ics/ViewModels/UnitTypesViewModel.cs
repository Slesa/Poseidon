using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class UnitTypesViewModel
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;

        public UnitTypesViewModel(IDbConversation dbConversation, IRegionManager regionManager)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;

            NewUnitTypeCommand = new DelegateCommand(OnNewUnitType);
            EditUnitTypeCommand = new DelegateCommand(OnEditUnitType, CanEditUnitType);
            DelUnitTypeCommand = new DelegateCommand(OnDelUnitType, CanDelUnitType);

            CreateDatasets();
        }

        public ObservableCollection<UnitType> UnitTypes { get; set; }

        #region Commands

        public ICommand NewUnitTypeCommand { get; private set; }

        void OnNewUnitType()
        {
            _regionManager.RequestNavigate(Regions.TagModulesRegion, View.EditUnitTypeView);
        }

        public ICommand EditUnitTypeCommand { get; private set; }

        void OnEditUnitType()
        {
            var uriQuery = new UriQuery {{"id", "1"}};
            _regionManager.RequestNavigate(Regions.TagModulesRegion, new Uri(View.EditUnitTypeView+uriQuery, UriKind.Relative));
        }

        bool CanEditUnitType()
        {
            return true;
        }

        public ICommand DelUnitTypeCommand { get; private set; }

        void OnDelUnitType()
        {
        }

        bool CanDelUnitType()
        {
            return true;
        }

        #endregion

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    UnitTypes = new ObservableCollection<UnitType>(_dbConversation.Query(new AllUnitTypesQuery()));
                });
        }
    }
}