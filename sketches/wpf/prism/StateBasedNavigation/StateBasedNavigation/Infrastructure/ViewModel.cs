using System;
using System.Windows;
using Microsoft.Practices.Prism.ViewModel;

namespace StateBasedNavigation.Infrastructure
{
    public class ViewModel : NotificationObject
    {
        protected void ExecuteOnUIThread(Action action)
        {
            var dispatcher = Application.Current.Dispatcher;

            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }
    }
}