using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.ViewModels
{
    public class EditUserRoleViewModel : INavigationAware
    {
        readonly IDbConversation _dbConversation;
        IRegionNavigationJournal _navigationJournal;
        IList<UserRole> _editedUserRoles = new List<UserRole>();

        public EditUserRoleViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;
        }

        public string Name { get; set; }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var userRoles = GetUserRoles(navigationContext);
            _dbConversation.UsingTransaction(() =>
                {
                    foreach (var userRoleId in userRoles)
                    {
                        var userRole = _dbConversation.GetById<UserRole>(userRoleId);
                        _editedUserRoles.Add(userRole);
                    }
                });
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

    }
}