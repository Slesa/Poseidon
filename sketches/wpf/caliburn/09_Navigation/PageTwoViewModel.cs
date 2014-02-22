using System.Windows;
using Caliburn.Micro;

namespace _09_Navigation
{
    public class PageTwoViewModel : Screen
    {
        protected override void OnActivate()
        {
            MessageBox.Show("Page Two Activated"); //Don't do this in a real VM.
            base.OnActivate();
        }
    }
}