using System;
using System.Globalization;

#if NETFX || WINDOWS_PHONE
using System.Windows;
using System.Windows.Data;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace ValueConverters
{
    public abstract class DateTimeConverterBase<TConverter> : SingletonConverterBase<TConverter>
        where TConverter : new()
    {
        protected const string DefaultFormat = "g";
        protected const string DefaultMinValueString = "";

        public abstract string Format { get; set; }
        public abstract string MinValueString { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is DateTime)
                {
                    var dateTime = (DateTime)value;
                    if (dateTime == DateTime.MinValue)
                    {
                        return this.MinValueString;
                    }
                    return dateTime.ToLocalTime().ToString(this.Format, culture);
                }
            }

            return UnsetValue;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is DateTime)
                {
                    return (DateTime)value;
                }
                var str = value as string;
                if (str != null)
                {
                    DateTime resultDateTime;
                    DateTime.TryParse(str, out resultDateTime);
                    return resultDateTime;
                }
            }
            return null;
        }
    }
}