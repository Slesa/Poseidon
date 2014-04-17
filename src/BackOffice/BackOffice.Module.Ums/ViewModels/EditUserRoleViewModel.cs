using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserRoleViewModel : EditItemsViewModel<UserRole>, INavigationAware
    {
        IRegionNavigationJournal _navigationJournal;
        readonly IList<UserRole> _editedUserRoles = new List<UserRole>();

        public EditUserRoleViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator) 
            : base(dbConversation, eventAggregator)
        {
            CommitCommand = new DelegateCommand(OnCommit);
        }

        public DelegateCommand CommitCommand { get; private set; }
        public override string TitleText { get { return EditMode==EditMode.Add ? "Add new user role" : "Edit user role"; } }

        public string Name
        {
            get { return CurrentEdit.Name; }
            set
            {
                CurrentEdit.Name = value;
                RaisePropertyChanged(()=>Name);
            }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var userRoles = GetUserRoles(navigationContext).ToList();
            if (userRoles.Any())
            {
                DbConversation.UsingTransaction(() =>
                    {
                        EditMode = EditMode.Edit;
                        var first = true;
                        foreach (var userRoleId in userRoles)
                        {
                            var userRole = DbConversation.GetById<UserRole>(userRoleId);
                            Name = EditItemsViewModel.GetTargetValue(first, CurrentEdit.Name, userRole.Name, null);
                            _editedUserRoles.Add(userRole);
                            first = false;
                        }
                    });
            }
            _navigationJournal = navigationContext.NavigationService.Journal;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }


        IEnumerable<int> GetUserRoles(NavigationContext navigationContext)
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
                    EventAggregator.GetEvent<UserRoleAddedEvent>().Publish(CurrentEdit);
                }
                else
                    foreach (var userRole in _editedUserRoles)
                    {
                        if(CurrentEdit.Name!=null) userRole.Name = CurrentEdit.Name;
                        EventAggregator.GetEvent<UserRoleChangedEvent>().Publish(userRole);
                    }
            });

            if (_navigationJournal != null)
                _navigationJournal.GoBack();
        }

    }
}