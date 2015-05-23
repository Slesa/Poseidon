using System;
using System.Windows.Input;

namespace Babelfisch.MvvmUtils
{
    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value; 
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _isEnabled;
        }

        public void Execute(object parameter)
        {
            if (_action != null) _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}