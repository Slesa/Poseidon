using System;
using System.Globalization;
using System.Windows.Data;

namespace Poseidon.BackOffice.Common.Converter
{
    public class StringEmptyToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var compare = value as string;
            return !string.IsNullOrEmpty(compare);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}