using System.Windows;
using System.Windows.Controls;

namespace Poseidon.Common.Prism.Extensions
{
    public class GroupStyleExtension
    {
        public static readonly DependencyProperty GroupStyleProperty =
            DependencyProperty.RegisterAttached("GroupStyle", typeof(GroupStyle), typeof(GroupStyleExtension), new UIPropertyMetadata(null, GroupStyleChanged));
 
        public static GroupStyle GetGroupStyle(DependencyObject obj)
        {
            return (GroupStyle) obj.GetValue(GroupStyleProperty);
        }

        public static void SetGroupStyle(DependencyObject obj, GroupStyle value)
        {
            obj.SetValue(GroupStyleProperty, value);
        }

        public static void GroupStyleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var itemsControl = sender as ItemsControl;
            if (itemsControl == null) return;

            var groupStyle = args.OldValue as GroupStyle;
            if (groupStyle != null)
                itemsControl.GroupStyle.Remove(groupStyle);

            groupStyle = args.NewValue as GroupStyle;
            if (groupStyle != null)
                itemsControl.GroupStyle.Add(groupStyle);
        }
    }
}