using System;
using System.Globalization;

#if NETFX || WINDOWS_PHONE
using System.Windows;
using System.Windows.Data;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace ValueConverters
{
    public abstract class DateTimeConverterBase : ConverterBase
    {
        protected const string DefaultFormat = "g";
        protected const string DefaultMinValueString = "";

        public abstract string Format { get; set; }
        public abstract string MinValueString { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (DateTime)value == DateTime.MinValue)
            {
                return this.MinValueString;
            }

            if (targetType == typeof(string))
            {
                return ((DateTime)value).ToLocalTime().ToString(this.Format, culture);
            }

            return UnsetValue;
        }
    }
}