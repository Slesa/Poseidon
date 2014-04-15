using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserRoleViewModel : NotificationObject, INavigationAware
    {
        readonly IDbConversation _dbConversation;
        IRegionNavigationJournal _navigationJournal;
        readonly IList<UserRole> _editedUserRoles = new List<UserRole>();
        readonly UserRole _currentEdit = new UserRole();

        public EditUserRoleViewModel(IDbConversation dbConversation)
        {
            EditMode = EditMode.Add;
            _dbConversation = dbConversation;
            CommitCommand = new DelegateCommand(OnCommit);
        }

        public DelegateCommand CommitCommand { get; private set; }
        public string TitleText { get { return EditMode==EditMode.Add ? "Add new user role" : "Edit user role"; } }

        public string Name
        {
            get { return _currentEdit.Name; }
            set
            {
                _currentEdit.Name = value;
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
                _dbConversation.UsingTransaction(() =>
                    {
                        EditMode = EditMode.Edit;
                        var first = true;
                        foreach (var userRoleId in userRoles)
                        {
                            var userRole = _dbConversation.GetById<UserRole>(userRoleId);
                            Name = EditItemsViewModel.GetTargetValue(first, _currentEdit.Name, userRole.Name, null);
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
            _dbConversation.UsingTransaction(() =>
            {
                if (EditMode == EditMode.Add)
                {
                    _dbConversation.Insert(_currentEdit);
                }
                else
                    foreach (var userRole in _editedUserRoles)
                    {
                        if(_currentEdit.Name!=null) userRole.Name = _currentEdit.Name;
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