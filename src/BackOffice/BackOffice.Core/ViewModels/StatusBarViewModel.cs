using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class StatusBarViewModel : NotificationObject
    {
        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            Message = string.Empty;
            eventAggregator.GetEvent<StatusBarClearEvent>().Subscribe(_ => Message = string.Empty);
            eventAggregator.GetEvent<StatusBarMessageEvent>().Subscribe(msg => Message = msg);
        }

        string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message == value) return;
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }
    }
}