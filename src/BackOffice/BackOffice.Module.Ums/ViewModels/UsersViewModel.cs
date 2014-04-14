using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class UsersViewModel : IUsersViewModel
    {
        readonly IDbConversation _dbConversation;
        readonly IRegionManager _regionManager;

        public UsersViewModel(IDbConversation dbConversation, IRegionManager regionManager)
        {
            _dbConversation = dbConversation;
            _regionManager = regionManager;

            CreateDatasets();

            AddNewUserCommand = new DelegateCommand(AddNewUser);
            EditUserCommand = new DelegateCommand(EditUser, CanEditUser);
            SelectedItems = new ObservableCollection<User>();
            SelectedItems.CollectionChanged += (sender, args) => ((DelegateCommand)EditUserCommand).RaiseCanExecuteChanged();
        }

        public ObservableCollection<User> Users { get; private set; }
        public ObservableCollection<User> SelectedItems { get; private set; }

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