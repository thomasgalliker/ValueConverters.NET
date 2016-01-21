using System;
using System.Globalization;

#if (NETFX || WINDOWS_PHONE)
using System.Windows;
using System.Windows.Data;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#elif (XAMARIN)
using Xamarin.Forms;
#endif

namespace ValueConverters
{
    public abstract class ConverterBase : 
#if XAMARIN
        BindableObject,
#else
        DependencyObject,
#endif
        IValueConverter
    {
        protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        protected virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException(string.Format("Converter '{0}' does not support backward conversion.", this.GetType().Name));
        }

#if (NETFX || WINDOWS_PHONE || XAMARIN)
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, culture);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.ConvertBack(value, targetType, parameter, culture);
        }
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
        object IValueConverter.Convert(object value, Type targetType, object parameter, string culture)
        {
            return this.Convert(value, targetType, parameter, new CultureInfo(culture));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return this.ConvertBack(value, targetType, parameter, new CultureInfo(culture));
        }
#endif

#if XAMARIN
        protected static readonly object UnsetValue = null;
#else
        protected static readonly object UnsetValue = DependencyProperty.UnsetValue;
#endif

    }
}