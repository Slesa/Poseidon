using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Events;
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

    public abstract class EditItemsViewModel<T> /*: NotificationObject, IDataErrorInfo*/
    {
        protected IDbConversation DbConversation;
        protected IEventAggregator EventAggregator;


        protected EditItemsViewModel(IDbConversation dbConversation, IEventAggregator eventAggregator)
        {
            DbConversation = dbConversation;
            EventAggregator = eventAggregator;
        }


        T _resultingElement;
        protected T ResultingElement
        {
            get { return _resultingElement; }
            set { _resultingElement = value; }
        }
    }
}