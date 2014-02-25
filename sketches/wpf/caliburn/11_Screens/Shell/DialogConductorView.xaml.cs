using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace _11_Screens.Shell 
{
    public partial class DialogConductorView : UserControl 
    {
        bool _disabled;

        public DialogConductorView() 
        {
            InitializeComponent();
            //ActiveItem.ContentChanged += OnTransitionCompleted;
            Loaded += OnLoad;
        }

        void OnLoad(object sender, RoutedEventArgs e) 
        {
            if(_disabled) DisableBackground();
        }

        void OnTransitionCompleted(object sender, EventArgs e) 
        {
            if(ActiveItem.Content == null)
                EnableBackground();
            else {
                DisableBackground();

                var control = ActiveItem.Content as Control;
                if(control != null)
                    control.Focus();
            }
        }

        public void EnableBackground() 
        {
            _disabled = false;
            ChangeEnabledState(GetBackground(), true);
        }

        public void DisableBackground() 
        {
            _disabled = true;
            ChangeEnabledState(GetBackground(), false);
        }

        IEnumerable<UIElement> GetBackground() 
        {
            var contentControl = (ContentControl)Parent;
            var container = (Panel)contentControl.Parent;
            return container.Children.Cast<object>().Where(child => child != contentControl).Cast<UIElement>();
        }

        void ChangeEnabledState(IEnumerable<UIElement> background, bool state) 
        {
            foreach(var uiElement in background) 
            {
                var control = uiElement as Control;
                if (control != null)
                    control.IsEnabled = state;
                else
                {
                    var panel = uiElement as Panel;
                    if (panel != null)
                    {
                        foreach (var child in panel.Children)
                        {
                            ChangeEnabledState(new List<UIElement>{child as UIElement}, state);
                        }
                    }
                }
            }
        }
    }
}