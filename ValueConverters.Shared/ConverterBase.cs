﻿using System.Diagnostics;
using System;
using System.Globalization;

#if (NETFX || WINDOWS_PHONE)
using System.Windows;
using System.Windows.Data;
#elif (NETFX_CORE)
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
            throw new NotSupportedException($"Converter '{this.GetType().Name}' does not support backward conversion.");
        }

#if (NETFX || WINDOWS_PHONE || XAMARIN)
        [DebuggerStepThrough]
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, culture);
        }

        [DebuggerStepThrough]
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.ConvertBack(value, targetType, parameter, culture);
        }
#elif (NETFX_CORE)
        [DebuggerStepThrough]
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            var cultureInfo = TryGetCultureInfo(language);
            return this.Convert(value, targetType, parameter, cultureInfo);
        }

        [DebuggerStepThrough]
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var cultureInfo = TryGetCultureInfo(language);
            return this.ConvertBack(value, targetType, parameter, cultureInfo);
        }

        private static CultureInfo TryGetCultureInfo(string language)
        {
            if (string.IsNullOrEmpty(language))
            {
                try
                {
                    return new CultureInfo(language);
                }
                catch
                {
                }
            }

            return CultureInfo.CurrentUICulture;
        }

#endif

#if XAMARIN
        public static readonly object UnsetValue = null;
#else
        public static readonly object UnsetValue = DependencyProperty.UnsetValue;
#endif

    }
}
