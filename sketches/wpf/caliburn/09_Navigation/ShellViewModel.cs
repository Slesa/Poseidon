using Caliburn.Micro;

namespace _09_Navigation
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ShowPageOne();
        }

        public void ShowPageOne()
        {
            ActivateItem(new PageOneViewModel());
        }

        public void ShowPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }
    }
}