using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.BackOffice.Module.Ums.Views;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel : IUsersViewModel, INavigationAware
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;

        public UsersViewModel(IDbConversation dbConversation, IRegionManager regionManager)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;

            CreateDatasets();

            AddNewUserCommand = new DelegateCommand(AddNewUser);
            EditUserCommand = new DelegateCommand(EditUser);
        }

        public ObservableCollection<User> Users { get; private set; }

        #region Commands

        public ICommand AddNewUserCommand { get; private set; }

        void AddNewUser()
        {
            _regionManager.RequestNavigate(Regions.TagModulesRegion, UmsViews.EditUserView);
/*
            var editUser = EditUserViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserView { DataContext = editUser };

            var dialog = new Window();
            dialog.Content = view;
            /*return #1#
            dialog.ShowDialog();
*/
        }

        public ICommand EditUserCommand { get; private set; }

        void EditUser()
        {
            var sb = new StringBuilder();
            sb.Append(UmsViews.EditUserView);
            var query = new UriQuery() { { "Selection", "1" } };
            sb.Append(query);
            _regionManager.RequestNavigate(Regions.TagModulesRegion, new Uri(sb.ToString(), UriKind.Relative));
/*
            var editUser = EditUserViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserView { DataContext = editUser };

            var dialog = new Window();
            dialog.Content = view;
            /*return #1#
            dialog.ShowDialog();
*/
        }

        #endregion

        void CreateDatasets()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        Users = new ObservableCollection<User>(_dbConversation.Query(new AllUsersQuery()));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new System.NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new System.NotImplementedException();
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new System.NotImplementedException();
        }
    }
}