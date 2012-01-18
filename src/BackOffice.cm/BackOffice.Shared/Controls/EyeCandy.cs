using System.Windows;
using System.Windows.Media;

namespace BackOffice.Shared.Controls
{
    // http://www.hardcodet.net/2009/01/create-wpf-image-button-through-attached-properties
    public class EyeCandy
    {
        /// <summary>
        /// An attached dependency property which provides an <see cref="ImageSource" /> for arbitrary WPF elements.
        /// </summary>
        public static readonly DependencyProperty ImageProperty;

        /// <summary>
        /// Gets the <see cref="ImageProperty"/> for a given <see cref="DependencyObject"/>, which provides an
        /// <see cref="ImageSource"/> for arbitrary WPF elements.
        /// </summary>
        public static ImageSource GetImage(DependencyObject obj)
        {
            return (ImageSource) obj.GetValue(ImageProperty);
        }

        /// <summary>
        /// Sets the attached <see cref="ImageProperty"/> for a given <see cref="DependencyObject"/>, which provides an
        /// <see cref="ImageSource" /> for arbitrary WPF elements.
        /// </summary>
        public static void SetImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageProperty, value);
        }

        static EyeCandy()
        {
            var metadata = new FrameworkPropertyMetadata((ImageSource) null);
            ImageProperty = DependencyProperty.RegisterAttached("Image", 
                typeof (ImageSource), typeof (EyeCandy), metadata);
        }
    }
}