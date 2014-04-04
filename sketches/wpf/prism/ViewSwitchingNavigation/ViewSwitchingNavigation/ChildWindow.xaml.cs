using System;
using System.Windows;
using System.Windows.Input;
using ViewSwitchingNavigation.Infrastructure;

namespace ViewSwitchingNavigation
{
    internal class ResultCommand : ICommand
    {
        public delegate void CommandOnExecute(PopupDialogResult result);
        private readonly CommandOnExecute _execute;

        public ResultCommand(CommandOnExecute execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke((PopupDialogResult)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

    public partial class ChildWindow : Window, IPopupDialogWindow
    {
        public ChildWindow()
        {
            InitializeComponent();
            DataContext = this;

            DialogResultCommand = new ResultCommand(
                result =>
                    {
                        DialogResult = result;
                        Close();
                    });
        }

        public PopupDialogResult DialogResult { get; set; }
        public ICommand DialogResultCommand { get; set; }
        public string MessageText { get; set; }
        public DataTemplate ContentTemplate { get; set; }
    }
}
