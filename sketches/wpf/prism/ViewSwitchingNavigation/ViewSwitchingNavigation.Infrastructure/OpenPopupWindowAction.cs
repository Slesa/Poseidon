using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.ServiceLocation;

namespace ViewSwitchingNavigation.Infrastructure
{
    public class OpenPopupWindowAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke(object parameter)
        {
            var args = parameter as InteractionRequestedEventArgs;
            if (args == null) return;

            var confirmation = (Confirmation) args.Context;

            var popup = ServiceLocator.Current.GetInstance<IPopupDialogWindow>();
            if (popup == null) return;

            var window = popup as Window;
            if(window!=null) window.Closed += (sender, eventArgs) =>
                {
                    var w = sender as IPopupDialogWindow;
                    confirmation.Confirmed = w.DialogResult==PopupDialogResult.OK;
                    args.Callback();
                };

            //popup.Owner = PlacementTarget ?? (Window)ServiceLocator.Current.GetInstance<IShell>();
            popup.Title = confirmation.Title;

            popup.MessageText = confirmation.Content as string;

            popup.Show();
        }

        public Window PlacementTarget
        {
            get { return (Window)GetValue(PlacementTargetProperty); }
            set { SetValue(PlacementTargetProperty, value); }
        }

        public static readonly DependencyProperty PlacementTargetProperty =
            DependencyProperty.Register("PlacementTarget", typeof(Window), typeof(OpenPopupWindowAction), new PropertyMetadata(null));
    }
}