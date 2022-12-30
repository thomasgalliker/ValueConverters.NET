using System;
using System.Globalization;

#if (NETFX || NETWPF)
using System.Windows;
using System.Windows.Data;
using Property = System.Windows.DependencyProperty;

#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Property = Windows.UI.Xaml.DependencyProperty;

#elif (XAMARIN)
using Xamarin.Forms;
using Property = Xamarin.Forms.BindableProperty;

#elif (MAUI)
using Microsoft.Maui;
using Property = Microsoft.Maui.Controls.BindableProperty;
#endif

namespace ValueConverters
{
    public abstract class ConverterBase :
#if XAMARIN || MAUI
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

        /// <summary>
        /// Converts <paramref name="value"/> from binding source to binding target.
        /// </summary>
        /// <param name="value">The value provided by the binding source.</param>
        /// <param name="targetType">The type of the binding target.</param>
        /// <param name="parameter">Additional parameter (optional).</param>
        /// <param name="culture">The preferred culture (see also <seealso cref="ConverterBase.PreferredCulture"/>)</param>
        /// <returns>The converted value.</returns>
        protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Converts back <paramref name="value"/> from binding target to binding source.
        /// </summary>
        /// <param name="value">The value provided by the binding target.</param>
        /// <param name="targetType">The type of the binding source.</param>
        /// <param name="parameter">Additional parameter (optional).</param>
        /// <param name="culture">The preferred culture (see also <seealso cref="ConverterBase.PreferredCulture"/>)</param>
        /// <returns>The converted value.</returns>
        protected virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"Converter '{this.GetType().Name}' does not support backward conversion.");
        }

#if (NETFX || NETWPF || XAMARIN || MAUI)
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


#if XAMARIN || MAUI
        public static readonly object UnsetValue = null;
#else
        public static readonly object UnsetValue = DependencyProperty.UnsetValue;
#endif

    }
}
