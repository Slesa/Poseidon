﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using Poseidon.Common.Wpf.Adorners;

namespace Poseidon.Common.Wpf.Services
{
    /// <summary>
    /// Class that provides the Watermark attached property
    /// <see cref="http://stackoverflow.com/questions/833943/watermark-hint-text-textbox-in-wpf"/>
    /// </summary>
    public class WatermarkService
    {
        /// <summary>
        /// Dictionary of ItemsControls
        /// </summary>
        private static readonly Dictionary<object, ItemsControl> itemsControls = new Dictionary<object, ItemsControl>();

        /// <summary>
        /// Watermark Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark",
            typeof(object),
            typeof(WatermarkService),
            new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnWatermarkChanged)));

        /// <summary>
        /// Gets the Watermark property.  This dependency property indicates the watermark for the control.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> to get the property from</param>
        /// <returns>The value of the Watermark property</returns>
        public static object GetWatermark(DependencyObject d)
        {
            return d.GetValue(WatermarkProperty);
        }

        /// <summary>
        /// Sets the Watermark property.  This dependency property indicates the watermark for the control.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> to set the property on</param>
        /// <param name="value">value of the property</param>
        public static void SetWatermark(DependencyObject d, object value)
        {
            d.SetValue(WatermarkProperty, value);
        }

        /// <summary>
        /// Handles changes to the Watermark property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Control)d;
            control.Loaded += Control_Loaded;

            if (d is ComboBox || d is TextBox)
            {
                control.GotKeyboardFocus += Control_GotKeyboardFocus;
                control.LostKeyboardFocus += Control_Loaded;
            }

            if (d is ItemsControl && !(d is ComboBox))
            {
                var i = (ItemsControl)d;

                // for Items property  
                i.ItemContainerGenerator.ItemsChanged += ItemsChanged;
                itemsControls.Add(i.ItemContainerGenerator, i);

                // for ItemsSource property  
                var prop = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, i.GetType());
                prop.AddValueChanged(i, ItemsSourceChanged);
            }
        }

        /// <summary>
        /// Handle the GotFocus event on the control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="RoutedEventArgs"/> that contains the event data.</param>
        static void Control_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            var c = (Control)sender;
            if (ShouldShowWatermark(c)) RemoveWatermark(c);
        }

        /// <summary>
        /// Handle the Loaded and LostFocus event on the control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="RoutedEventArgs"/> that contains the event data.</param>
        static void Control_Loaded(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            if (ShouldShowWatermark(control)) ShowWatermark(control);
        }

        /// <summary>
        /// Event handler for the items source changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        static void ItemsSourceChanged(object sender, EventArgs e)
        {
            var c = (ItemsControl)sender;
            if (c.ItemsSource == null || ShouldShowWatermark(c))
            {
                ShowWatermark(c);
            }
            else
            {
                RemoveWatermark(c);
            }
        }

        /// <summary>
        /// Event handler for the items changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="ItemsChangedEventArgs"/> that contains the event data.</param>
        static void ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            ItemsControl control;
            if (itemsControls.TryGetValue(sender, out control))
            {
                if (ShouldShowWatermark(control))
                {
                    ShowWatermark(control);
                }
                else
                {
                    RemoveWatermark(control);
                }
            }
        }

        /// <summary>
        /// Show the watermark on the specified control
        /// </summary>
        /// <param name="control">Control to show the watermark on</param>
        static void ShowWatermark(Control control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);

            // layer could be null if control is no longer in the visual tree
            if (layer != null)
            {
                layer.Add(new WatermarkAdorner(control, GetWatermark(control)));
            }
        }

        /// <summary>
        /// Remove the watermark from the specified element
        /// </summary>
        /// <param name="control">Element to remove the watermark from</param>
        static void RemoveWatermark(UIElement control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);

            // layer could be null if control is no longer in the visual tree
            if (layer != null)
            {
                var adorners = layer.GetAdorners(control);
                if (adorners == null)
                {
                    return;
                }

                foreach (var adorner in adorners)
                {
                    if (adorner is WatermarkAdorner)
                    {
                        adorner.Visibility = Visibility.Hidden;
                        layer.Remove(adorner);
                    }
                }
            }
        }

        /// <summary>
        /// Indicates whether or not the watermark should be shown on the specified control
        /// </summary>
        /// <param name="c"><see cref="Control"/> to test</param>
        /// <returns>true if the watermark should be shown; false otherwise</returns>
        static bool ShouldShowWatermark(Control c)
        {
            if (c is ComboBox)
            {
                return (c as ComboBox).Text == string.Empty;
            }
            if (c is TextBoxBase)
            {
                return (c as TextBox).Text == string.Empty;
            }
            if (c is ItemsControl)
            {
                return (c as ItemsControl).Items.Count == 0;
            }
            return false;
        }
    }
}