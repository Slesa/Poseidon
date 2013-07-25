using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.BackOffice.Core.Contracts;
using Poseidon.Common.Prism;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class StatusBarViewModel : NotificationObject, IStatusBarViewModel
    {
        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ClearMessageEvent>().Subscribe(_ => Message = null);
            eventAggregator.GetEvent<ShowMessageEvent>().Subscribe(msg => Message = msg);
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