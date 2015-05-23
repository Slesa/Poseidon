using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UserRolesViewModel
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;
        readonly IEventAggregator _eventAggregator;

        public UserRolesViewModel(IDbConversation dbConversation, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            CreateDatasets();

            AddNewUserRoleCommand = new DelegateCommand(AddNewUserRole);
            EditUserRoleCommand = new DelegateCommand(EditUserRole, CanEditUserRole);
            RemoveUserRoleCommand = new DelegateCommand(RemoveUserRole, CanRemoveUserRole);
            SelectedItems = new ObservableCollection<UserRoleViewModel>();
            SelectedItems.CollectionChanged += (sender, args) =>
                {
                    ((DelegateCommand) EditUserRoleCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand) RemoveUserRoleCommand).RaiseCanExecuteChanged();
                };

            _eventAggregator.GetEvent<UserRoleAddedEvent>().Subscribe(OnUserRoleAdded);
            _eventAggregator.GetEvent<UserRoleChangedEvent>().Subscribe(OnUserRoleChanged);
            _eventAggregator.GetEvent<UserRoleRemovedEvent>().Subscribe(OnUserRoleRemoved);
        }

        public ObservableCollection<UserRoleViewModel> UserRoles { get; private set; }
        public ObservableCollection<UserRoleViewModel> SelectedItems { get; private set; }
    
    #region Commands

        public ICommand AddNewUserRoleCommand { get; private set; }

        void AddNewUserRole()
        {
            _regionManager.RequestNavigate(Regions.TagModulesRegion, UmsViews.EditUserRoleView);
        }

        public ICommand EditUserRoleCommand { get; private set; }

        void EditUserRole()
        {
            var selection = SelectedItems.Select(x => x.Id.ToString(CultureInfo.InvariantCulture));

            var sb = new StringBuilder();
            sb.Append(UmsViews.EditUserRoleView);
            var query = new NavigationParameters {{"Selection", string.Join(",", selection)}};
            sb.Append(query);
            _regionManager.RequestNavigate(Regions.TagModulesRegion, new Uri(sb.ToString(), UriKind.Relative));
        }

        bool CanEditUserRole()
        {
            return SelectedItems.Any();
        }

        public ICommand RemoveUserRoleCommand { get; private set; }

        void RemoveUserRole()
        {
            var removed = new List<int>();
            _dbConversation.UsingTransaction(() =>
                {
                    foreach (var viewModel in SelectedItems)
                    {
                        _dbConversation.Remove(_dbConversation.GetById<UserRole>(viewModel.Id));
                        removed.Add(viewModel.Id);
                    }
                });
            foreach(var id in removed) _eventAggregator.GetEvent<UserRoleRemovedEvent>().Publish(id);
        }

        bool CanRemoveUserRole()
        {
            return SelectedItems.Any();
        }

    #endregion

    #region Events

        void OnUserRoleAdded(UserRole userRole)
        {
            UserRoles.Add(new UserRoleViewModel(userRole));
        }

        void OnUserRoleChanged(UserRole userRole)
        {
            var viewModel = UserRoles.FirstOrDefault(x => x.Id == userRole.Id);
            if(viewModel!=null) viewModel.UseDataFrom(userRole);
        }

        void OnUserRoleRemoved(int id)
        {
            UserRoles.Remove(UserRoles.FirstOrDefault(x=>x.Id==id));
        }

    #endregion

        void CreateDatasets()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        UserRoles = new ObservableCollection<UserRoleViewModel>(_dbConversation.Query(new AllUserRolesQuery()).Select(x=>new UserRoleViewModel(x)));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}