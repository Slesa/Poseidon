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
    public class UserRolesViewModel : IUserRolesViewModel
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;

        public UserRolesViewModel(IDbConversation dbConversation, IRegionManager regionManager)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;

            CreateDatasets();

            AddNewUserRoleCommand = new DelegateCommand(AddNewUserRole);
            EditUserRoleCommand = new DelegateCommand(EditUserRole);
        }

        public ObservableCollection<UserRole> UserRoles { get; private set; }

    #region Commands

        public ICommand AddNewUserRoleCommand { get; private set; }

        void AddNewUserRole()
        {
            _regionManager.RequestNavigate(Regions.TagModulesRegion, UmsViews.EditUserRoleView);
/*
            var editUserRole = EditUserRoleViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserRoleView {DataContext = editUserRole};

            var dialog = new Window();
            dialog.Content = view;
            /*return #1#dialog.ShowDialog();
*/
        }

        public ICommand EditUserRoleCommand { get; private set; }

        void EditUserRole()
        {
            var sb = new StringBuilder();
            sb.Append(UmsViews.EditUserRoleView);
            var query = new UriQuery() {{"Selection", "1"}};
            sb.Append(query);
            _regionManager.RequestNavigate(Regions.TagModulesRegion, new Uri(sb.ToString(), UriKind.Relative));

            /*
            var editUserRole = EditUserRoleViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserRoleView {DataContext = editUserRole};

            var dialog = new Window();
            dialog.Content = view;
            /*return #1#dialog.ShowDialog();
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
                        UserRoles = new ObservableCollection<UserRole>(_dbConversation.Query(new AllUserRolesQuery()));
                    });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}