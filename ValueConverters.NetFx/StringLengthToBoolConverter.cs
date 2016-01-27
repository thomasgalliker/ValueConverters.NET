using System;
using System.Globalization;

namespace ValueConverters
{
    public class StringLengthToBoolConverter : ConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value as string);
        }
    }
}
