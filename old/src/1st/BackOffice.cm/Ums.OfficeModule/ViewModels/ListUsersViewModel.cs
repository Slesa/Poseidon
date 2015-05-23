using System;
using System.ComponentModel.Composition;
using System.Linq;
using BackOffice.Shared.Events;
using BackOffice.Shared.ViewModels;
using Caliburn.Micro;
using Ums.NHibernate.Queries;
using Ums.OfficeModule.Model;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.ViewModels
{
    [Export(typeof(ListUsersViewModel))]
    public class ListUsersViewModel : SelectionListViewModel<UserRowViewModel>
        , IHandle<UserChangedEvent>
        , IHandle<UserRemovedEvent>
    {
        public ListUsersViewModel() 
            : base(Strings.ListUsersTitle)
        {
            EventAggregator.Subscribe(this);
        }

        public void Add()
        {
            EventAggregator.Publish(new ActivateScreenEvent(EditUserViewModel.CreateViewModel(DbConversation, EventAggregator)));
        }

        public void Edit()
        {
            var user = ElementList.Where(row => row.IsSelected).FirstOrDefault();
            if (user != null)
                EventAggregator.Publish(new ActivateScreenEvent(
                    EditUserViewModel.CreateViewModel(user.Id, DbConversation, EventAggregator)));
        }

        public void Open(UserRowViewModel viewModel)
        {
            EventAggregator.Publish(new ActivateScreenEvent(
                EditUserViewModel.CreateViewModel(viewModel.Id, DbConversation, EventAggregator)));
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

        public void Handle(UserChangedEvent message)
        {
            var viewmodel = (from vm in ElementList where vm.Id == message.User.Id select vm).FirstOrDefault();
            if (viewmodel == null)
            {
                viewmodel = new UserRowViewModel(message.User);
                ElementList.Add(viewmodel);
                ConnectElement(viewmodel);
            }
            else
            {
                viewmodel.ExchangeData(message.User);
                viewmodel.Refresh();
            }
            NotifyOfPropertyChange(() => ItemSelected);
            NotifyOfPropertyChange(() => ItemsSelected);
        }

        public void Handle(UserRemovedEvent message)
        {
            var viewmodel = (from vm in ElementList where vm.Id == message.Id select vm).FirstOrDefault();
            if (viewmodel != null)
                ElementList.Remove(viewmodel);
        }
    }
}