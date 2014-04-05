using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using StateBasedNavigation.Infrastructure;
using StateBasedNavigation.Model;

namespace StateBasedNavigation.ViewModels
{
    public class SendMessageViewModel : Notification, INotifyPropertyChanged
    {
        private readonly Contact contact;
        private readonly ChatViewModel parent;
        private bool? result;
        private string message;

        public SendMessageViewModel(Contact contact, ChatViewModel parent)
        {
            this.contact = contact;
            this.parent = parent;
        }

        public string TitleText
        {
            get
            {
                return string.Format("Send message to {0}", Contact.Name);
            }
        }
        public Contact Contact
        {
            get { return contact; }
        }

        public string Message
        {
            get { return message; }
            set
            {
                if (value == message) return;
                message = value;
                RaisePropertyChanged(() => this.Message);
            }
        }


        public bool? Result
        {
            get { return result; }
            set
            {
                if (value == result) return;
                result = value;
                RaisePropertyChanged(() => this.Result);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        void RaisePropertyChanged<T>(Expression<Func<T>> lambda)
        {
            var name = PropertySupport.ExtractPropertyName<T>(lambda);
            OnPropertyChanged(name);
        }
    }
}