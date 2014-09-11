using System;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class StatusBarViewModel : BindableBase
    {
        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            Message = string.Empty;
            eventAggregator.GetEvent<StatusBarClearEvent>().Subscribe(_ => Message = string.Empty);
            eventAggregator.GetEvent<StatusBarMessageEvent>().Subscribe(OnMessage);
        }

        void OnMessage(string msg)
        {
            Message = msg;
            Task.Factory.StartNew(() => Task.Delay(3000).ContinueWith(new Action<Task>(_ => Message = string.Empty)));
        }

        string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message == value) return;
                _message = value;
                OnPropertyChanged(() => Message);
            }
        }
    }
}