using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Poseidon.Common.Wpf.Behaviors
{
    public class MouseDoubleClickBehavior : Behavior<ListBox>
    {
        public static DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(MouseDoubleClickBehavior),
                new UIPropertyMetadata(CommandChanged));

        public static DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached(
                "CommandParameter",
                typeof(object),
                typeof(MouseDoubleClickBehavior),
                new UIPropertyMetadata(null));

        public static void SetCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(CommandProperty, value);
        }

        public static void SetCommandParameter(DependencyObject target, object value)
        {
            target.SetValue(CommandParameterProperty, value);
        }
        public static object GetCommandParameter(DependencyObject target)
        {
            return target.GetValue(CommandParameterProperty);
        }

        static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var control = target as Control;
            if (control == null) return;

            if ((e.NewValue != null) && (e.OldValue == null))
            {
                control.MouseDoubleClick += OnMouseDoubleClick;
            }
            else if ((e.NewValue == null) && (e.OldValue != null))
            {
                control.MouseDoubleClick -= OnMouseDoubleClick;
            }
        }

        static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            var command = (ICommand)control.GetValue(CommandProperty);
            var commandParameter = control.GetValue(CommandParameterProperty);
            command.Execute(commandParameter);
        }
    }
}