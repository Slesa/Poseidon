using System.ComponentModel.Composition;
using System.Linq;
using BackOffice.Shared.Events;
using BackOffice.Shared.ViewModels;
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
            EventAggregator.Publish(new ActivateScreenEvent(EditUserRoleViewModel.CreateViewModel(DbConversation)));
        }

        public void Edit()
        {
            var userRole = ElementList.Where(row => row.IsSelected).FirstOrDefault();
            if( userRole!=null )
                EventAggregator.Publish(new ActivateScreenEvent(
                    EditUserRoleViewModel.CreateViewModel(userRole.Id, DbConversation)));
        }

        public void Open(UserRoleRowViewModel viewModel)
        {
            EventAggregator.Publish(new ActivateScreenEvent(
                EditUserRoleViewModel.CreateViewModel(viewModel.Id, DbConversation)));
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
