using System.ComponentModel.Composition;
using System.Linq;
using BackOffice.Shared.Events;
using BackOffice.Shared.ViewModels;
using Caliburn.Micro;
using Ums.NHibernate.Queries;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.ViewModels
{
    [Export(typeof(ListUsersViewModel))]
    public class ListUsersViewModel : SelectionListViewModel<UserRowViewModel>
    {
        public ListUsersViewModel() 
            : base(Strings.ListUsersTitle)
        {
            EventAggregator.Subscribe(this);
        }

        public void Add()
        {
            EventAggregator.Publish(new ActivateScreenEvent(EditUserViewModel.CreateViewModel(DbConversation)));
        }

        public void Edit()
        {
            var user = ElementList.Where(row => row.IsSelected).FirstOrDefault();
            if (user != null)
                EventAggregator.Publish(new ActivateScreenEvent(
                    EditUserViewModel.CreateViewModel(user.Id, DbConversation)));
        }

        public void Open(UserRowViewModel viewModel)
        {
            EventAggregator.Publish(new ActivateScreenEvent(
                EditUserViewModel.CreateViewModel(viewModel.Id, DbConversation)));
        }

        public void Remove()
        {
        }

        protected override BindableCollection<UserRowViewModel> CreateElementList()
        {
            return new BindableCollection<UserRowViewModel>(DbConversation
                .Query(new AllUsersQuery())
                .Select(x=>new UserRowViewModel(x)));
        }
    }
}