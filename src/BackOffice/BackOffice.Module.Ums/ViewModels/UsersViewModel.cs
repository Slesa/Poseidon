using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;
        readonly IEventAggregator _eventAggregator;

        public UsersViewModel(IDbConversation dbConversation, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            CreateDatasets();

            AddNewUserCommand = new DelegateCommand(AddNewUser);
            EditUserCommand = new DelegateCommand(EditUser, CanEditUser);
            RemoveUserCommand = new DelegateCommand(RemoveUser, CanRemoveUser);
            SelectedItems = new ObservableCollection<UserViewModel>();
            SelectedItems.CollectionChanged += (sender, args) =>
                {
                    ((DelegateCommand) EditUserCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand) RemoveUserCommand).RaiseCanExecuteChanged();
                };

            _eventAggregator.GetEvent<UserAddedEvent>().Subscribe(OnUserAdded);
            _eventAggregator.GetEvent<UserChangedEvent>().Subscribe(OnUserChanged);
            _eventAggregator.GetEvent<UserRemovedEvent>().Subscribe(OnUserRemoved);
            _eventAggregator.GetEvent<UserRoleChangedEvent>().Subscribe(OnUserRoleChanged);
        }

        public ObservableCollection<UserViewModel> Users { get; private set; }
        public ObservableCollection<UserViewModel> SelectedItems { get; private set; }

    #region Commands

        public ICommand AddNewUserCommand { get; private set; }

        void AddNewUser()
        {
            _regionManager.RequestNavigate(Regions.TagModulesRegion, UmsViews.EditUserView);
        }

        public ICommand EditUserCommand { get; private set; }

        void EditUser()
        {
            var selection = SelectedItems.Select(x => x.Id.ToString(CultureInfo.InvariantCulture));

            var sb = new StringBuilder();
            sb.Append(UmsViews.EditUserView);
            var query = new UriQuery() { { "Selection", string.Join(",", selection) } };
            sb.Append(query);
            _regionManager.RequestNavigate(Regions.TagModulesRegion, new Uri(sb.ToString(), UriKind.Relative));
        }

        bool CanEditUser()
        {
            return SelectedItems.Any();
        }

        public ICommand RemoveUserCommand { get; private set; }

        void RemoveUser()
        {
            var removed = new List<int>();
            _dbConversation.UsingTransaction(() =>
                {
                    foreach (var viewModel in SelectedItems)
                    {
                        _dbConversation.Remove(_dbConversation.GetById<User>(viewModel.Id));
                        removed.Add(viewModel.Id);
                    }
                });
            foreach (var id in removed) _eventAggregator.GetEvent<UserRemovedEvent>().Publish(id);
        }

        bool CanRemoveUser()
        {
            return SelectedItems.Any();
        }

    #endregion

    #region Events

        void OnUserAdded(User user)
        {
            Users.Add(new UserViewModel(user));
        }

        void OnUserChanged(User user)
        {
            var viewModel = Users.FirstOrDefault(x => x.Id == user.Id);
            if (viewModel != null) viewModel.UseDataFrom(user);
        }

        void OnUserRemoved(int id)
        {
            Users.Remove(Users.FirstOrDefault(x => x.Id == id));
        }

        void OnUserRoleChanged(UserRole userRole)
        {
        }

    #endregion

        void CreateDatasets()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        Users = new ObservableCollection<UserViewModel>(_dbConversation.Query(new AllUsersQuery()).Select(x=>new UserViewModel(x)));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}