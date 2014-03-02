using Caliburn.Micro;
using Poseidon.BackOffice.Core.Contracts;
using Poseidon.BackOffice.Core.Events;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class StatusBarViewModel : PropertyChangedBase, IStatusBarViewModel
        , IHandle<StatusBarMessageEvent>
        , IHandle<StatusBarClearEvent>
    {
        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            Message = string.Empty;
            eventAggregator.Subscribe(this);
        }

        string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(()=>Message);
            }
        }

        public void Handle(StatusBarMessageEvent mevent)
        {
            Message = mevent.Message;
        }

        public void Handle(StatusBarClearEvent message)
        {
            Message = string.Empty;
        }
    }
}