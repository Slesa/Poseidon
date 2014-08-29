using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.Common.Persistence.Contracts;

namespace Poseidon.BackOffice.Common.ViewModels
{
    public enum EditMode
    {
        Add,
        Edit
    }

    public static class EditItemsViewModel 
    {
        public static W GetTargetValue<W>(bool firstCall, W currentValue, W itemValue, W emptyValue) 
        {
            if (firstCall) return itemValue;
            return currentValue.Equals(itemValue) ? itemValue : emptyValue;
        }
    }

    public abstract class EditItemsViewModel<T> : NotificationObject /*, IDataErrorInfo*/ where T : new()
    {
        protected readonly IDbConversation DbConversation;
        protected readonly IEventAggregator EventAggregator;
        protected readonly T CurrentEdit = new T();


        protected EditItemsViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            EditMode = EditMode.Add;
            DbConversation = dbConversation;
            EventAggregator = eventAggregator;
        }

        public abstract string TitleText { get; }

        EditMode _editMode;
        protected EditMode EditMode
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