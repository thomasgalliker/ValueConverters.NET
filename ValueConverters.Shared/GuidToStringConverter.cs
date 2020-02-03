using System;

namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(Guid), typeof(string))]
#endif
    public class GuidToStringConverter : SingletonConverterBase<GuidToStringConverter>
    {
        public bool ToUpper { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Guid guid)
            {
                var guidString = guid.ToString("D");

                if (this.ToUpper)
                {
                    return guidString.ToUpperInvariant();
                }

                return guidString;
            }

            return UnsetValue;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string guidString)
            {
                var guid = new Guid(guidString);
                return guid;
            }

            return UnsetValue;
        }
    }
}
