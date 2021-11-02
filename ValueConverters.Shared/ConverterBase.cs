using System;
using System.Globalization;

#if (NETFX || NET5_0_OR_GREATER)
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
        /// <summary>
        /// Allows to override the default culture used in <seealso cref="IValueConverter"/> for the current converter.
        /// The default override behavior can be configured in <seealso cref="ValueConvertersConfig.DefaultPreferredCulture"/>.
        /// </summary>
        public PreferredCulture PreferredCulture { get; set; } = ValueConvertersConfig.DefaultPreferredCulture;

        protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        protected virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"Converter '{this.GetType().Name}' does not support backward conversion.");
        }


#if (NETFX || NET5_0_OR_GREATER || XAMARIN)
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, this.SelectCulture(() => culture));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.ConvertBack(value, targetType, parameter, this.SelectCulture(() => culture));
        }
#elif (NETFX_CORE)
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            var cultureInfo = this.SelectCulture(() => TryConvertToCultureInfo(language));
            return this.Convert(value, targetType, parameter, cultureInfo);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var cultureInfo = this.SelectCulture(() => TryConvertToCultureInfo(language));
            return this.ConvertBack(value, targetType, parameter, cultureInfo);
        }

        private static CultureInfo TryConvertToCultureInfo(string language)
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
        private CultureInfo SelectCulture(Func<CultureInfo> converterCulture)
        {
            switch (this.PreferredCulture)
            {
                case PreferredCulture.CurrentCulture:
                    return CultureInfo.CurrentCulture;
                case PreferredCulture.CurrentUICulture:
                    return CultureInfo.CurrentUICulture;
                default:
                    return converterCulture();
            }
        }


#if XAMARIN
        public static readonly object UnsetValue = null;
#else
        public static readonly object UnsetValue = DependencyProperty.UnsetValue;
#endif

    }
}
