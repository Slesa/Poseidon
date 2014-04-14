using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserViewModel : INavigationAware
    {
        readonly IDbConversation _dbConversation;
        IRegionNavigationJournal _navigationJournal;
        IList<User> _editedUsers = new List<User>();

        public EditUserViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;
            dbConversation.UsingTransaction(() =>
                AllUserRoles = dbConversation.Query(new AllUserRolesQuery()).ToList());
        }

        public string Name { get; set; }
        public UserRole UserRole { get; set; }
        public List<UserRole> AllUserRoles { get; private set; }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var users = GetUsers(navigationContext);
            _dbConversation.UsingTransaction(() =>
            {
                foreach (var userId in users)
                {
                    var user = _dbConversation.GetById<User>(userId);
                    _editedUsers.Add(user);
                }
            });
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
    }
}