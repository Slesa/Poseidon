using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Poseidon.Common.Wpf.Behaviors
{
    public class SelectAllOnFocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseDoubleClick += OnMouseSelection;
            AssociatedObject.GotKeyboardFocus += OnKeyboardFocusSelectText;
            AssociatedObject.PreviewMouseDown += IgnoreMouseDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseDoubleClick -= OnMouseSelection;
            AssociatedObject.GotKeyboardFocus -= OnKeyboardFocusSelectText;
            AssociatedObject.PreviewMouseDown -= IgnoreMouseDown;
        }

        private void OnKeyboardFocusSelectText(object sender, KeyboardFocusChangedEventArgs e)
        {
            AssociatedObject.SelectAll();
        }

        private void OnMouseSelection(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.SelectAll();
        }

        private void IgnoreMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox == null) return;

            if (textbox.IsKeyboardFocusWithin) return;

            e.Handled = true;
            textbox.Focus();
        }

    }
}