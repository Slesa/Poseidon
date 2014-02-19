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
    [Export(typeof(ListUserRolesViewModel))]
    public class ListUserRolesViewModel : SelectionListViewModel<UserRoleRowViewModel>
        //, IHandle<UserRoleChangedEvent>
        //, IHandle<UserRoleRemovedEvent>
    {
        public ListUserRolesViewModel() 
            : base(Strings.ListUserRolesTitle)
        {
            EventAggregator.Subscribe(this);
        }

        public void Add()
        {
            //EventAggregator.Publish(new ActivateScreenEvent(new EditUserRoleViewModel()));
        }

        public void Edit()
        {
            //var userRole = ElementList.Where(row => row.IsSelected).FirstOrDefault();
            //if( userRole!=null )
            //    EventAggregator.Publish(new ActivateScreenEvent(
            //        new EditUserRoleViewModel(userRole.Id)));
        }

        public void Open(UserRoleRowViewModel viewModel)
        {
            //EventAggregator.Publish(new ActivateScreenEvent(
            //    new EditUserRoleViewModel(viewModel.Id)));
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

        /*
        public void Handle(UserRoleChangedEvent message)
        {
            var viewmodel = (from vm in ElementList where vm.Id == message.UserRole.Id select vm).FirstOrDefault();
            if (viewmodel == null)
            {
                viewmodel = new UserRoleRowViewModel(message.UserRole);
                ElementList.Add(viewmodel);
                ConnectElement(viewmodel);
            }
            else
            {
                viewmodel.ExchangeData(message.UserRole);
                viewmodel.Refresh();
            }
            NotifyOfPropertyChange(() => ItemSelected);
            NotifyOfPropertyChange(() => ItemsSelected);
        }

        public void Handle(UserRoleRemovedEvent message)
        {
            var viewmodel = (from vm in ElementList where vm.Id == message.Id select vm).FirstOrDefault();
            if (viewmodel != null)
                ElementList.Remove(viewmodel);
        }*/
    }
}
