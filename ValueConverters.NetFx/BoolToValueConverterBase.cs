using System.Globalization;
using System;

#if NETFX || WINDOWS_PHONE
using System.Windows;
using System.Windows.Data;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace ValueConverters
{
    /// <summary>
    /// The idea for BoolToValueConverter comes from here:
    /// http://geekswithblogs.net/codingbloke/archive/2010/05/28/a-generic-boolean-value-converter.aspx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BoolToValueConverterBase<T> : ConverterBase
    {
        public abstract T TrueValue { get; set; }

        public abstract T FalseValue { get; set; }

        public abstract bool IsInverted { get; set; }

        protected override sealed object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var returnValue = this.FalseValue;

            if (value != null)
            {
                if (this.IsInverted)
                {
                    returnValue = (bool)value ? this.FalseValue : this.TrueValue;
                }
                else
                {
                    returnValue = (bool)value ? this.TrueValue : this.FalseValue;
                }
            }

            return returnValue;
        }

        protected override sealed object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool returnValue = false;

            if (value != null)
            {
                if (this.IsInverted)
                {
                    returnValue = value.Equals(this.FalseValue);
                }
                else
                {
                    returnValue = value.Equals(this.TrueValue);
                }
            }

            return returnValue;
        }
    }
}