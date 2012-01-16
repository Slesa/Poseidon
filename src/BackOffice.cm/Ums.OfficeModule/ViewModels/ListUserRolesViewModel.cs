using System.ComponentModel.Composition;
using System.Linq;
using BackOffice.Shared;
using Caliburn.Micro;
using Ums.NHibernate.Queries;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.ViewModels
{
    [Export(typeof(ListUserRolesViewModel))]
    public class ListUserRolesViewModel : SelectionListViewModel<UserRoleRowViewModel>
    {
        public ListUserRolesViewModel() 
            : base(Strings.ListUserRolesTitle)
        {
            EventAggregator.Subscribe(this);
        }

        public void Add()
        {
        }

        public void Edit()
        {
        }

        public void Open(UserRoleRowViewModel viewModel)
        {
        }

        public void Remove()
        {
        }
        
        protected override BindableCollection<UserRoleRowViewModel> CreateElementList()
        {
            return new BindableCollection<UserRoleRowViewModel>(DbConversation
                .Query(new AllUserRolesQuery())
                .Select(x=>new UserRoleRowViewModel(x)));
        }
    }
}
