using System;
using System.Globalization;

namespace ValueConverters
{
    public class StringToDecimalConverter : SingletonConverterBase<StringToDecimalConverter>
    {
        private static readonly NumberStyles DefaultNumberStyles = NumberStyles.Any;
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dec = value as decimal?;
            if (dec != null)
            {
                return dec.Value.ToString("G", culture ?? CultureInfo.InvariantCulture);
            }

            var str = value as string;
            if (str != null)
            {
                decimal result;
                if (decimal.TryParse(str, DefaultNumberStyles, culture ?? CultureInfo.InvariantCulture, out result))
                {
                    return result;
                }

                return result;
            }

            return UnsetValue;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, culture);
        }
    }
}
