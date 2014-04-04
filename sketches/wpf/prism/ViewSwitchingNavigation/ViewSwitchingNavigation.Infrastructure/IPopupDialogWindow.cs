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
        //object Owner { get; set; }
        string Title { get; set; }
        string MessageText { get; set; }
    }
}