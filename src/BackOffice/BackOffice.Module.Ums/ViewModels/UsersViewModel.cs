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
    public class UsersViewModel : IUsersViewModel
    {
        readonly IDbConversation _dbConversation;

        public UsersViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();

            AddNewUserCommand = new DelegateCommand(AddNewUser);
            EditUserCommand = new DelegateCommand(EditUser);
        }

        public ObservableCollection<User> Users { get; private set; }

        #region Commands

        public ICommand AddNewUserCommand { get; private set; }

        void AddNewUser()
        {
            var editUser = EditUserViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserView { DataContext = editUser };

            var dialog = new Window();
            dialog.Content = view;
            /*return */
            dialog.ShowDialog();
        }

        public ICommand EditUserCommand { get; private set; }

        void EditUser()
        {
            var editUser = EditUserViewModel.CreateViewModel(_dbConversation);
            var view = new EditUserView { DataContext = editUser };

            var dialog = new Window();
            dialog.Content = view;
            /*return */
            dialog.ShowDialog();
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
    }
}