using System;
using System.Globalization;
using System.Windows.Data;

namespace StateBasedNavigation.Infrastructure
{
    public class StringMatchToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = value as bool?;
            if (boolean.HasValue)
            {
                return parameter;
            }
            return null;
        }
    }
}