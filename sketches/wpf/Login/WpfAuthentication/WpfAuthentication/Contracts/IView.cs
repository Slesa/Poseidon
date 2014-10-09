namespace WpfAuthentication.Contracts
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }

        void Show();
    }
}