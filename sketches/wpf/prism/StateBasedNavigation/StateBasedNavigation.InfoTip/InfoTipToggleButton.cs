using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;

namespace StateBasedNavigation.InfoTip
{
    [ContentProperty("TipContent")]
    public class InfoTipToggleButton : ToggleButton
    {
        public static readonly DependencyProperty TipContentProperty = DependencyProperty.Register("TipContent", typeof(object), typeof(InfoTipToggleButton), new PropertyMetadata(null));
        public static readonly DependencyProperty TipContentStyleProperty = DependencyProperty.Register("TipContentStyle", typeof(Style), typeof(InfoTipToggleButton), new PropertyMetadata(null));
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor", typeof(Brush), typeof(InfoTipToggleButton), new PropertyMetadata(null));
        private static WeakReference _weakOpenToggleButton;
        private Popup _popup;
        private WeakReference _weakPopup;

        public object TipContent
        {
            get { return GetValue(TipContentProperty); }
            set { SetValue(TipContentProperty, value); }
        }

        public Style TipContentStyle
        {
            get { return (Style)GetValue(TipContentStyleProperty); }
            set { SetValue(TipContentStyleProperty, value); }
        }

        public Brush FillColor
        {
            get { return GetValue(FillColorProperty) as Brush; }
            set { SetValue(FillColorProperty, value); }
        }

        static InfoTipToggleButton()
        {
        }

        public InfoTipToggleButton()
        {
            DefaultStyleKey = typeof(InfoTipToggleButton);
            Loaded += ToggleButton_Loaded;
            Checked += ToggleButton_IsCheckedChanged;
            Unchecked += ToggleButton_IsCheckedChanged;
            Unloaded += ToggleButton_Unloaded;
        }

        private void CreatePopup()
        {
            var contentControl = new ContentControl { Content = TipContent, DataContext = DataContext };
            if (TipContentStyle != null)
                contentControl.Style = TipContentStyle;
            _popup = new Popup
            {
                Child = contentControl
            };
        }

        private void OpenPopup()
        {
            if (_weakOpenToggleButton != null && _weakOpenToggleButton.IsAlive && _weakOpenToggleButton.Target != this)
                ((ToggleButton)_weakOpenToggleButton.Target).IsChecked = false;
            if (_popup == null)
            {
                if (_weakPopup != null && _weakPopup.IsAlive)
                    _popup = (Popup)_weakPopup.Target;
                else
                    CreatePopup();
                var contentControl = _popup.Child as ContentControl;
                if (contentControl != null && contentControl.Content == null)
                    contentControl.Content = TipContent;
                ((FrameworkElement)_popup.Child).SizeChanged += PopupContent_SizeChanged;
            }
            PositionPopup();
            _popup.IsOpen = true;
            _weakOpenToggleButton = new WeakReference(this);
        }

        private void ClosePopup()
        {
            if (_popup == null)
                return;
            var contentControl = _popup.Child as ContentControl;
            if (contentControl != null)
                contentControl.Content = null;
            _popup.IsOpen = false;
            if (_weakOpenToggleButton != null && _weakOpenToggleButton.IsAlive && _weakOpenToggleButton.Target == this)
                _weakOpenToggleButton = null;
            _weakPopup = new WeakReference(_popup);
            ((FrameworkElement)_popup.Child).SizeChanged -= PopupContent_SizeChanged;
            _popup = null;
        }

        private void PositionPopup()
        {
            if (_popup == null || DesignerProperties.GetIsInDesignMode(this))
                return;
            //Control control = (Control)Application.Current.RootVisual;
            var control = (Control)Application.Current.MainWindow;
            var frameworkElement = (FrameworkElement)_popup.Child;
            var generalTransform = TransformToVisual(control);
            var point1 = generalTransform.Transform(new Point(ActualWidth + 2.0, ActualHeight + 2.0));
            var point2 = new Point(point1.X + frameworkElement.ActualWidth, point1.Y + frameworkElement.ActualHeight);
            if (IsPointWithinActualArea(control, point1) && IsPointWithinActualArea(control, point2))
            {
                _popup.HorizontalOffset = point1.X;
                _popup.VerticalOffset = point1.Y;
            }
            else
            {
                point1 = generalTransform.Transform(new Point(-2.0, ActualHeight + 2.0));
                point2 = new Point(point1.X - frameworkElement.ActualWidth, point1.Y + frameworkElement.ActualHeight);
                if (IsPointWithinActualArea(control, point1) && IsPointWithinActualArea(control, point2))
                {
                    _popup.HorizontalOffset = point2.X;
                    _popup.VerticalOffset = point1.Y;
                }
                else
                {
                    point1 = generalTransform.Transform(new Point(ActualWidth + 2.0, -2.0));
                    point2 = new Point(point1.X + frameworkElement.ActualWidth, point1.Y - frameworkElement.ActualHeight);
                    if (IsPointWithinActualArea(control, point1) && IsPointWithinActualArea(control, point2))
                    {
                        _popup.HorizontalOffset = point1.X;
                        _popup.VerticalOffset = point2.Y;
                    }
                    else
                    {
                        point1 = generalTransform.Transform(new Point(-2.0, -2.0));
                        point2 = new Point(point1.X - frameworkElement.ActualWidth, point1.Y - frameworkElement.ActualHeight);
                        if (IsPointWithinActualArea(control, point1) && IsPointWithinActualArea(control, point2))
                        {
                            _popup.HorizontalOffset = point2.X;
                            _popup.VerticalOffset = point2.Y;
                        }
                        else
                        {
                            point1 = generalTransform.Transform(new Point(ActualWidth + 2.0, ActualHeight + 2.0));
                            _popup.HorizontalOffset = point1.X;
                            _popup.VerticalOffset = point1.Y;
                        }
                    }
                }
            }
        }

        private static bool IsPointWithinActualArea(Control control, Point point)
        {
            if (point.X >= 0.0 && point.X <= control.ActualWidth && point.Y >= 0.0)
                return point.Y <= control.ActualHeight;
            return false;
        }

        void ToggleButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            //((FrameworkElement)Application.Current.RootVisual).SizeChanged += new SizeChangedEventHandler(this.RootVisual_SizeChanged);
            Application.Current.MainWindow.SizeChanged += RootVisual_SizeChanged;
        }

        void ToggleButton_Unloaded(object sender, RoutedEventArgs e)
        {
            ClosePopup();
        }

        void ToggleButton_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            var isChecked = IsChecked;
            if ((!isChecked.GetValueOrDefault() ? 0 : (isChecked.HasValue ? 1 : 0)) != 0)
                OpenPopup();
            else
                ClosePopup();
        }

        void RootVisual_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PositionPopup();
        }

        void PopupContent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PositionPopup();
        }
    }
}