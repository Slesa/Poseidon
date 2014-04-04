﻿using System.Windows;
using System.Windows.Input;
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
           
            var popup = ServiceLocator.Current.GetInstance<IPopupDialogWindow>();
            //popup.Owner = PlacementTarget ?? (Window)ServiceLocator.Current.GetInstance<IShell>();
            var window = popup as Window;
            window.Title = args.Context.Title;
            //window.Content = args.Context.Content;
            window.Closed += (sender, eventArgs) => args.Callback();

            popup.DialogResultCommand = PopupDailogResultCommand;
            popup.Show();

        }

        public Window PlacementTarget
        {
            get { return (Window)GetValue(PlacementTargetProperty); }
            set { SetValue(PlacementTargetProperty, value); }
        }

        public static readonly DependencyProperty PlacementTargetProperty =
            DependencyProperty.Register("PlacementTarget", typeof(Window), typeof(OpenPopupWindowAction), new PropertyMetadata(null));


        public ICommand PopupDailogResultCommand
        {
            get { return (ICommand)GetValue(PopupDailogResultCommandProperty); }
            set { SetValue(PopupDailogResultCommandProperty, value); }
        }

        public static readonly DependencyProperty PopupDailogResultCommandProperty =
            DependencyProperty.Register("PopupDailogResultCommand", typeof(ICommand), typeof(OpenPopupWindowAction), new PropertyMetadata(null));
    }
}