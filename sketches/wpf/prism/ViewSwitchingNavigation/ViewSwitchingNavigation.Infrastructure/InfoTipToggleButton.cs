using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;

namespace ViewSwitchingNavigation.Infrastructure
{
    [ContentProperty("TipContent")]
    public class InfoTipToggleButton : ToggleButton
    {
        public static readonly DependencyProperty TipContentProperty = DependencyProperty.Register("TipContent", typeof(object), typeof(InfoTipToggleButton), new PropertyMetadata((PropertyChangedCallback)null));
        public static readonly DependencyProperty TipContentStyleProperty = DependencyProperty.Register("TipContentStyle", typeof(Style), typeof(InfoTipToggleButton), new PropertyMetadata((PropertyChangedCallback)null));
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor", typeof(Brush), typeof(InfoTipToggleButton), new PropertyMetadata((PropertyChangedCallback)null));
        private static WeakReference weakOpenToggleButton;
        private Popup popup;
        private WeakReference weakPopup;

        public object TipContent
        {
            get
            {
                return this.GetValue(InfoTipToggleButton.TipContentProperty);
            }
            set
            {
                this.SetValue(InfoTipToggleButton.TipContentProperty, value);
            }
        }

        public Style TipContentStyle
        {
            get
            {
                return (Style)this.GetValue(InfoTipToggleButton.TipContentStyleProperty);
            }
            set
            {
                this.SetValue(InfoTipToggleButton.TipContentStyleProperty, (object)value);
            }
        }

        public Brush FillColor
        {
            get
            {
                return this.GetValue(InfoTipToggleButton.FillColorProperty) as Brush;
            }
            set
            {
                this.SetValue(InfoTipToggleButton.FillColorProperty, (object)value);
            }
        }

        static InfoTipToggleButton()
        {
        }

        public InfoTipToggleButton()
        {
            this.DefaultStyleKey = (object)typeof(InfoTipToggleButton);
            this.Loaded += new RoutedEventHandler(this.ToggleButton_Loaded);
            this.Checked += new RoutedEventHandler(this.ToggleButton_IsCheckedChanged);
            this.Unchecked += new RoutedEventHandler(this.ToggleButton_IsCheckedChanged);
            this.Unloaded += new RoutedEventHandler(this.ToggleButton_Unloaded);
        }

        private void CreatePopup()
        {
            ContentControl contentControl = new ContentControl();
            contentControl.Content = this.TipContent;
            contentControl.DataContext = this.DataContext;
            if (this.TipContentStyle != null)
                contentControl.Style = this.TipContentStyle;
            this.popup = new Popup()
            {
                Child = (UIElement)contentControl
            };
        }

        private void OpenPopup()
        {
            if (InfoTipToggleButton.weakOpenToggleButton != null && InfoTipToggleButton.weakOpenToggleButton.IsAlive && InfoTipToggleButton.weakOpenToggleButton.Target != this)
                ((ToggleButton)InfoTipToggleButton.weakOpenToggleButton.Target).IsChecked = new bool?(false);
            if (this.popup == null)
            {
                if (this.weakPopup != null && this.weakPopup.IsAlive)
                    this.popup = (Popup)this.weakPopup.Target;
                else
                    this.CreatePopup();
                ContentControl contentControl = this.popup.Child as ContentControl;
                if (contentControl != null && contentControl.Content == null)
                    contentControl.Content = this.TipContent;
                ((FrameworkElement)this.popup.Child).SizeChanged += new SizeChangedEventHandler(this.PopupContent_SizeChanged);
            }
            this.PositionPopup();
            this.popup.IsOpen = true;
            InfoTipToggleButton.weakOpenToggleButton = new WeakReference((object)this);
        }

        private void ClosePopup()
        {
            if (this.popup == null)
                return;
            ContentControl contentControl = this.popup.Child as ContentControl;
            if (contentControl != null)
                contentControl.Content = (object)null;
            this.popup.IsOpen = false;
            if (InfoTipToggleButton.weakOpenToggleButton != null && InfoTipToggleButton.weakOpenToggleButton.IsAlive && InfoTipToggleButton.weakOpenToggleButton.Target == this)
                InfoTipToggleButton.weakOpenToggleButton = (WeakReference)null;
            this.weakPopup = new WeakReference((object)this.popup);
            ((FrameworkElement)this.popup.Child).SizeChanged -= new SizeChangedEventHandler(this.PopupContent_SizeChanged);
            this.popup = (Popup)null;
        }

        private void PositionPopup()
        {
            if (this.popup == null || DesignerProperties.GetIsInDesignMode(this))
                return;
            //Control control = (Control)Application.Current.RootVisual;
            Control control = (Control)Application.Current.MainWindow;
            FrameworkElement frameworkElement = (FrameworkElement)this.popup.Child;
            GeneralTransform generalTransform = this.TransformToVisual((UIElement)control);
            Point point1 = generalTransform.Transform(new Point(this.ActualWidth + 2.0, this.ActualHeight + 2.0));
            Point point2 = new Point(point1.X + frameworkElement.ActualWidth, point1.Y + frameworkElement.ActualHeight);
            if (InfoTipToggleButton.IsPointWithinActualArea(control, point1) && InfoTipToggleButton.IsPointWithinActualArea(control, point2))
            {
                this.popup.HorizontalOffset = point1.X;
                this.popup.VerticalOffset = point1.Y;
            }
            else
            {
                point1 = generalTransform.Transform(new Point(-2.0, this.ActualHeight + 2.0));
                point2 = new Point(point1.X - frameworkElement.ActualWidth, point1.Y + frameworkElement.ActualHeight);
                if (InfoTipToggleButton.IsPointWithinActualArea(control, point1) && InfoTipToggleButton.IsPointWithinActualArea(control, point2))
                {
                    this.popup.HorizontalOffset = point2.X;
                    this.popup.VerticalOffset = point1.Y;
                }
                else
                {
                    point1 = generalTransform.Transform(new Point(this.ActualWidth + 2.0, -2.0));
                    point2 = new Point(point1.X + frameworkElement.ActualWidth, point1.Y - frameworkElement.ActualHeight);
                    if (InfoTipToggleButton.IsPointWithinActualArea(control, point1) && InfoTipToggleButton.IsPointWithinActualArea(control, point2))
                    {
                        this.popup.HorizontalOffset = point1.X;
                        this.popup.VerticalOffset = point2.Y;
                    }
                    else
                    {
                        point1 = generalTransform.Transform(new Point(-2.0, -2.0));
                        point2 = new Point(point1.X - frameworkElement.ActualWidth, point1.Y - frameworkElement.ActualHeight);
                        if (InfoTipToggleButton.IsPointWithinActualArea(control, point1) && InfoTipToggleButton.IsPointWithinActualArea(control, point2))
                        {
                            this.popup.HorizontalOffset = point2.X;
                            this.popup.VerticalOffset = point2.Y;
                        }
                        else
                        {
                            point1 = generalTransform.Transform(new Point(this.ActualWidth + 2.0, this.ActualHeight + 2.0));
                            this.popup.HorizontalOffset = point1.X;
                            this.popup.VerticalOffset = point1.Y;
                        }
                    }
                }
            }
        }

        private static bool IsPointWithinActualArea(Control control, Point point)
        {
            if (point.X >= 0.0 && point.X <= control.ActualWidth && point.Y >= 0.0)
                return point.Y <= control.ActualHeight;
            else
                return false;
        }

        private void ToggleButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            //((FrameworkElement)Application.Current.RootVisual).SizeChanged += new SizeChangedEventHandler(this.RootVisual_SizeChanged);
            ((FrameworkElement)Application.Current.MainWindow).SizeChanged += new SizeChangedEventHandler(this.RootVisual_SizeChanged);
        }

        private void ToggleButton_Unloaded(object sender, RoutedEventArgs e)
        {
            this.ClosePopup();
        }

        private void ToggleButton_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            bool? isChecked = this.IsChecked;
            if ((!isChecked.GetValueOrDefault() ? 0 : (isChecked.HasValue ? 1 : 0)) != 0)
                this.OpenPopup();
            else
                this.ClosePopup();
        }

        private void RootVisual_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.PositionPopup();
        }

        private void PopupContent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.PositionPopup();
        }
    }
}