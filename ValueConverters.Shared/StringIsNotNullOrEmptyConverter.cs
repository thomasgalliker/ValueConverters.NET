using System;
using System.Globalization;

namespace ValueConverters
{
    [Obsolete("StringLengthToBoolConverter has been renamed to StringIsNotNullOrEmptyConverter. Please use StringIsNotNullOrEmptyConverter. StringLengthToBoolConverter will be removed in future releases.")]
    public class StringLengthToBoolConverter : StringIsNotNullOrEmptyConverter
    {
    }

#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(string), typeof(bool))]
#endif
    public class StringIsNotNullOrEmptyConverter : SingletonConverterBase<StringIsNotNullOrEmptyConverter>
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value as string);
        }
    }
}
