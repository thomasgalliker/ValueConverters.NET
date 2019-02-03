using System;
using System.Globalization;

namespace ValueConverters
{
    [Obsolete("StringLengthToBoolConverter has been renamed to StringIsNotNullOrEmptyConverter. Please use StringIsNotNullOrEmptyConverter. StringLengthToBoolConverter will be removed in future releases.")]
    public class StringLengthToBoolConverter : StringIsNotNullOrEmptyConverter
    {
    }

    public class StringIsNotNullOrEmptyConverter : SingletonConverterBase<StringIsNotNullOrEmptyConverter>
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value as string);
        }
    }
}
