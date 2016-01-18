using System;
using System.Globalization;

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    /// <summary>
    /// EnumToBoolConverter can be used to bind to RadioButtons.
    /// </summary>
    // Source: http://stackoverflow.com/questions/397556/how-to-bind-radiobuttons-to-an-enum
    public class EnumToBoolConverter : ConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterString = parameter as string;
            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }

            if (Enum.IsDefined(value.GetType(), value) == false)
            {
                return DependencyProperty.UnsetValue;
            }

            var parameterValue = Enum.Parse(value.GetType(), parameterString);

            return parameterValue.Equals(value);
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterString = parameter as string;
            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, parameterString);
        }
    }
}