using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#if (NETFX || NETWPF)
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

#elif (XAMARIN)
using Xamarin.Forms;

#elif (MAUI)
using Microsoft.Maui;
using Microsoft.Maui.Controls;
#endif

namespace ValueConverters
{
    /// <summary>
    /// Value converters which aggregates the results of a sequence of converters: Converter1 >> Converter2 >> Converter3
    /// The output of converter N becomes the input of converter N+1.
    /// </summary>
#if (NETFX || NETWPF || XAMARIN || MAUI)
    [ContentProperty(nameof(Converters))]
#elif (NETFX_CORE)
    [ContentProperty(Name = nameof(Converters))]
#endif
    public class ValueConverterGroup : SingletonConverterBase<ValueConverterGroup>
    {
        public List<IValueConverter>? Converters { get; set; } = new List<IValueConverter>();

        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (this.Converters is IEnumerable<IValueConverter> converters)
            {
#if NETFX_CORE
                var language = culture?.ToString();
#else
                var language = culture;
#endif
                return converters.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, language));
            }

            return UnsetValue;
        }

        protected override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (this.Converters is IEnumerable<IValueConverter> converters)
            {
#if NETFX_CORE
                var language = culture?.ToString();
#else
                var language = culture;
#endif
                return converters.Reverse<IValueConverter>().Aggregate(value, (current, converter) => converter.ConvertBack(current, targetType, parameter, language));
            }

            return UnsetValue;
        }
    }
}
