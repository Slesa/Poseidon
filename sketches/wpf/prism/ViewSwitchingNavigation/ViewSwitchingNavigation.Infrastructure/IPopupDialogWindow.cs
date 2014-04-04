namespace ViewSwitchingNavigation.Infrastructure
{
    public enum PopupDialogResult
    {
        OK,
        Cancel
    };

    public interface IPopupDialogWindow
    {
        void Show();
        PopupDialogResult DialogResult { get; set; }
        System.Windows.Input.ICommand DialogResultCommand { get; set; }
        //object Owner { get; set; }
    }
}