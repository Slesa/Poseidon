using System.ComponentModel.Composition;
using System.Linq;
using BackOffice.Shared;
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
        }

        public void Edit()
        {
        }

        public void Open(UserRowViewModel viewModel)
        {
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