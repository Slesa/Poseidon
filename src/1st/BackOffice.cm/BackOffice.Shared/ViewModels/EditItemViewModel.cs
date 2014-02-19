using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using BackOffice.Shared.Resources;
using Caliburn.Micro;
using NHibernate;
using Persistence.Shared;

namespace BackOffice.Shared.ViewModels
{
    public abstract class EditItemViewModel<T> : Screen where T: PropertyChangedBase, IDataErrorInfo
    {
        //[Import] // TODO: Importing would be nice
        protected IDbConversation DbConversation;
        //[Import] // TODO: Importing would be nice
        protected IEventAggregator EventAggregator;

        T _element;
        protected T Element
        {
            get { return _element; }
            set { _element = value; _element.PropertyChanged += OnPropertyChanged; }
        }
        
        protected EditItemViewModel()
        {
            DbConversation = IoC.Get<IDbConversation>();
            EventAggregator = IoC.Get<IEventAggregator>();
        }

        public bool CanSave
        {
            get { return Error == null; }
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            if( !close )
                TryClose();
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

        protected bool SuccessfullySaved(System.Action action)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                DbConversation.UsingTransaction(action);
                NotifyOfPropertyChange(() => DisplayName);
                Mouse.OverrideCursor = null;
                return true;
            }
            catch (StaleObjectStateException)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show(SharedStrings.Error_StaleObject);
                return false;
            }
            catch (Exception exception)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show(SharedStrings.Error_CouldNotSaveObject + "\n\n" + exception.Message);
                return false;
            }
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Error")
                return;
            NotifyOfPropertyChange(()=>CanSave);
        }
    }
}