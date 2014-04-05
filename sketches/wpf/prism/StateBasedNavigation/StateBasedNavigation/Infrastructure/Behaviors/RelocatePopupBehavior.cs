using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace StateBasedNavigation.Infrastructure.Behaviors
{
    public class RelocatePopupBehavior : Behavior<Popup>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Opened += OnPopupOpened;
            AssociatedObject.Closed += OnPopupClosed;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Opened -= OnPopupOpened;
            AssociatedObject.Closed -= OnPopupClosed;

            DetachSizeChangeHandlers();

            base.OnDetaching();
        }

        void OnPopupOpened(object sender, EventArgs e)
        {
            UpdatePopupOffsets();
            AttachSizeChangeHandlers();
        }

        void OnPopupClosed(object sender, EventArgs e)
        {
            DetachSizeChangeHandlers();
        }

        void AttachSizeChangeHandlers()
        {
            var child = AssociatedObject.Child as FrameworkElement;
            if (child != null)
            {
                child.SizeChanged += OnChildSizeChanged;
            }

            var parent = AssociatedObject.Parent as FrameworkElement;
            if (parent != null)
            {
                parent.SizeChanged += OnParentSizeChanged;
            }
        }

        void DetachSizeChangeHandlers()
        {
            var child = AssociatedObject.Child as FrameworkElement;
            if (child != null)
            {
                child.SizeChanged -= OnChildSizeChanged;
            }

            var parent = AssociatedObject.Parent as FrameworkElement;
            if (parent != null)
            {
                parent.SizeChanged -= OnParentSizeChanged;
            }
        }

        void OnChildSizeChanged(object sender, EventArgs e)
        {
            UpdatePopupOffsets();
        }

        void OnParentSizeChanged(object sender, EventArgs e)
        {
            UpdatePopupOffsets();
        }

        private void UpdatePopupOffsets()
        {
            if (AssociatedObject != null)
            {
                var child = AssociatedObject.Child as FrameworkElement;
                var parent = AssociatedObject.Parent as FrameworkElement;

                if (child != null && parent != null)
                {
                    var anchor = new Point(parent.ActualWidth, parent.ActualHeight);

                    AssociatedObject.HorizontalOffset = anchor.X - child.ActualWidth;
                    AssociatedObject.VerticalOffset = anchor.Y - child.ActualHeight;
                }
            }
        }
    }
}