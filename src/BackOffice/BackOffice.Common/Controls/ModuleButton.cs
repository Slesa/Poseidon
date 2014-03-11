using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Poseidon.BackOffice.Common.Controls
{
    public class ModuleButton : Button
    {
        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof (double), typeof (ModuleButton), new PropertyMetadata(default(double)));

        public double TitleFontSize
        {
            get { return (double) GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        public static readonly DependencyProperty TitleFontWeightProperty =
            DependencyProperty.Register("TitleFontWeight", typeof (FontWeight), typeof (ModuleButton), new PropertyMetadata(default(FontWeight)));

        public FontWeight TitleFontWeight
        {
            get { return (FontWeight) GetValue(TitleFontWeightProperty); }
            set { SetValue(TitleFontWeightProperty, value); }
        }

        public static readonly DependencyProperty IconFileProperty =
            DependencyProperty.Register("IconFile", typeof(ImageSource), typeof(ModuleButton), new PropertyMetadata(default(ImageSource)));

        public ImageSource IconFile
        {
            get { return (ImageSource)GetValue(IconFileProperty); }
            set { SetValue(IconFileProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof (double), typeof (ModuleButton), new PropertyMetadata(default(double)));

        public double IconSize
        {
            get { return (double) GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof (string), typeof (ModuleButton), new PropertyMetadata(default(string)));

        public string Description
        {
            get { return (string) GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
    }
}