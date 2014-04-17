using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserViewModel : EditItemsViewModel<User>, INavigationAware
    {
        IRegionNavigationJournal _navigationJournal;
        readonly IList<User> _editedUsers = new List<User>();

        public EditUserViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator) 
            : base(dbConversation, eventAggregator)
        {
            dbConversation.UsingTransaction(() =>
                AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList());
            CommitCommand = new DelegateCommand(OnCommit);
        }

        public DelegateCommand CommitCommand { get; private set; }
        public override string TitleText { get { return EditMode == EditMode.Add ? "Add new user" : "Edit user"; } }

        public string Name
        {
            get { return CurrentEdit.Name; }
            set
            {
                CurrentEdit.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public UserRole UserRole
        {
            get { return CurrentEdit.UserRole; }
            set
            {
                CurrentEdit.UserRole = value;
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
                DbConversation.UsingTransaction(() =>
                    {
                        EditMode = EditMode.Edit;
                        var first = true;
                        foreach (var userId in users)
                        {
                            var user = DbConversation.GetById<User>(userId);
                            Name = EditItemsViewModel.GetTargetValue(first, CurrentEdit.Name, user.Name, null);
                            UserRole = EditItemsViewModel.GetTargetValue(first, CurrentEdit.UserRole, user.UserRole, null);
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
            DbConversation.UsingTransaction(() =>
            {
                if (EditMode == EditMode.Add)
                {
                    DbConversation.Insert(CurrentEdit);
                    EventAggregator.GetEvent<UserAddedEvent>().Publish(CurrentEdit);
                }
                else
                    foreach (var user in _editedUsers)
                    {
                        if(CurrentEdit.Name!=null) user.Name = CurrentEdit.Name;
                        if(CurrentEdit.UserRole!=null) user.UserRole = CurrentEdit.UserRole;
                        EventAggregator.GetEvent<UserChangedEvent>().Publish(user);
                    }
            });

            if (_navigationJournal != null)
                _navigationJournal.GoBack();
        }
    }
}