using System.ComponentModel;
using Caliburn.Micro;
using Persistence.Shared;

namespace BackOffice.Shared.ViewModels
{
    public abstract class EditItemViewModel<T> : Screen where T: PropertyChangedBase, IDataErrorInfo
    {
        protected T Element;
        protected IDbConversation DbConversation;

        protected EditItemViewModel(IDbConversation dbConversation)
        {
            DbConversation = dbConversation;
        }

        public bool CanSave
        {
            get { return Error == null; }
        }

        protected override void OnDeactivate(bool close)
        {
            if( !close )
                TryClose();
            else
                base.OnDeactivate(true);
        }

        public void Close()
        {
            TryClose();
        }

        public string this[string propertyName]
        {
            get { return Element[propertyName]; }
        }

        public string Error
        {
            get { return Element.Error; }
        }
    }
}