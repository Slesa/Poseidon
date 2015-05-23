using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace StateBasedNavigation.Infrastructure
{
    public class ShowNotificationAction : TargetedTriggerAction<FrameworkElement>
    {
        public static readonly DependencyProperty NotificationTimeoutProperty =
            DependencyProperty.Register("NotificationTimeout", typeof(TimeSpan), typeof(ShowNotificationAction), new PropertyMetadata(new TimeSpan(0, 0, 5)));

        readonly ObservableCollection<object> _notifications;

        public ShowNotificationAction()
        {
            _notifications = new ObservableCollection<object>();
        }

        public TimeSpan NotificationTimeout
        {
            get { return (TimeSpan)GetValue(NotificationTimeoutProperty); }

            set { SetValue(NotificationTimeoutProperty, value); }
        }

        protected override void OnTargetChanged(FrameworkElement oldTarget, FrameworkElement newTarget)
        {
            base.OnTargetChanged(oldTarget, newTarget);

            if (oldTarget != null)
            {
                Target.ClearValue(FrameworkElement.DataContextProperty);
            }

            if (newTarget != null)
            {
                Target.DataContext = _notifications;
            }
        }

        protected override void Invoke(object parameter)
        {
            var args = parameter as InteractionRequestedEventArgs;
            if (args == null)
            {
                return;
            }

            var notification = args.Context;

            _notifications.Insert(0, notification);

            var timer = new DispatcherTimer { Interval = NotificationTimeout };
            EventHandler timerCallback = null;
            timerCallback =
                (o, e) =>
                {
                    timer.Stop();
                    timer.Tick -= timerCallback;
                    _notifications.Remove(notification);
                };
            timer.Tick += timerCallback;
            timer.Start();

            args.Callback();
        }
         
    }
}