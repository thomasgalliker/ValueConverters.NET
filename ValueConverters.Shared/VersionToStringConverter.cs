using System;
using System.Globalization;

namespace ValueConverters
{
    public class VersionToStringConverter : ConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var version = value as Version;
            if (version != null)
            {
                if (int.TryParse(parameter as string, out int fieldCount))
                {
                    return version.ToString(fieldCount);
                }

                return version.ToString();
            }

            return UnsetValue;
        }
    }
}