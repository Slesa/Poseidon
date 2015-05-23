using System;
using System.Globalization;
using System.Windows.Data;

namespace StateBasedNavigation.Infrastructure
{
    public class SizeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return ((int) value) > 0;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}