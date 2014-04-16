using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserViewModel : NotificationObject, INavigationAware
    {
        readonly IDbConversation _dbConversation;
        readonly IEventAggregator _eventAggregator;
        IRegionNavigationJournal _navigationJournal;
        readonly IList<User> _editedUsers = new List<User>();
        readonly User _currentEdit = new User();

        public EditUserViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            EditMode = EditMode.Add;
            _dbConversation = dbConversation;
            _eventAggregator = eventAggregator;
            dbConversation.UsingTransaction(() =>
                AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList());
            CommitCommand = new DelegateCommand(OnCommit);
        }

        public DelegateCommand CommitCommand { get; private set; }
        public string TitleText { get { return EditMode == EditMode.Add ? "Add new user" : "Edit user"; } }

        public string Name
        {
            get { return _currentEdit.Name; }
            set
            {
                _currentEdit.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public UserRole UserRole
        {
            get { return _currentEdit.UserRole; }
            set
            {
                _currentEdit.UserRole = value;
                RaisePropertyChanged(() => UserRole);
            }
        }

        public List<UserRole> AllUserRoles { get; private set; }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var users = GetUsers(navigationContext).ToList();
            if (users.Any())
            {
                _dbConversation.UsingTransaction(() =>
                    {
                        EditMode = EditMode.Edit;
                        var first = true;
                        foreach (var userId in users)
                        {
                            var user = _dbConversation.GetById<User>(userId);
                            Name = EditItemsViewModel.GetTargetValue(first, _currentEdit.Name, user.Name, null);
                            UserRole = EditItemsViewModel.GetTargetValue(first, _currentEdit.UserRole, user.UserRole, null);
                            _editedUsers.Add(user);
                            first = false;
                        }
                    });
            }
            _navigationJournal = navigationContext.NavigationService.Journal;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }


        IEnumerable<int> GetUsers(NavigationContext navigationContext)
        {
            var selection = navigationContext.Parameters["Selection"];
            if (selection == null) yield break;

            foreach (var item in selection.Split(','))
            {
                int value;
                if (int.TryParse(item, out value)) yield return value;
            }
        }


        void OnCommit()
        {
            _dbConversation.UsingTransaction(() =>
            {
                if (EditMode == EditMode.Add)
                {
                    _dbConversation.Insert(_currentEdit);
                    _eventAggregator.GetEvent<UserAddedEvent>().Publish(_currentEdit);
                }
                else
                    foreach (var user in _editedUsers)
                    {
                        if(_currentEdit.Name!=null) user.Name = _currentEdit.Name;
                        if(_currentEdit.UserRole!=null) user.UserRole = _currentEdit.UserRole;
                        _eventAggregator.GetEvent<UserChangedEvent>().Publish(user);
                    }
            });

            if (_navigationJournal != null)
                _navigationJournal.GoBack();
        }

        EditMode _editMode;
        EditMode EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                RaisePropertyChanged(() => TitleText);
            }
        }
    }
}