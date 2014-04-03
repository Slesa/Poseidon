using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
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

        public UserRolesViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();

            AddNewUserRoleCommand = new DelegateCommand(AddNewUserRole);
            EditUserRoleCommand = new DelegateCommand(EditUserRole);
        }

        public ObservableCollection<UserRole> UserRoles { get; private set; }

    #region Commands

        public ICommand AddNewUserRoleCommand { get; private set; }

        void AddNewUserRole()
        {
            var editUserRole = EditUserRoleViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserRoleView {DataContext = editUserRole};

            var dialog = new Window();
            dialog.Content = view;
            /*return */dialog.ShowDialog();
        }

        public ICommand EditUserRoleCommand { get; private set; }

        void EditUserRole()
        {
            var editUserRole = EditUserRoleViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserRoleView {DataContext = editUserRole};

            var dialog = new Window();
            dialog.Content = view;
            /*return */dialog.ShowDialog();
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