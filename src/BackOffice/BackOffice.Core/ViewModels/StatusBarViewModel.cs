using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Practices.Prism.Events;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class StatusBarViewModel : IStatusBarViewModel
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
                _message = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}