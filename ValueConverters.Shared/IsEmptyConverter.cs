using System;
using System.Collections;
using System.Globalization;

#if NETFX || NETWPF
using System.Windows;

#elif NETFX_CORE
using Windows.UI.Xaml;

#elif (XAMARIN)
using Xamarin.Forms;

#elif (MAUI)
using Microsoft.Maui;
#endif

namespace ValueConverters
{
    public class IsEmptyConverter : SingletonConverterBase<IsEmptyConverter>
    {
#if XAMARIN || MAUI
        public static readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
            "IsInverted",
            typeof(bool),
            typeof(IsEmptyConverter),
            default(bool));
#else
        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            "IsInverted",
            typeof(bool),
            typeof(IsEmptyConverter),
            new PropertyMetadata(false));
#endif

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable enumerable)
            {
                var hasAtLeastOne = enumerable.GetEnumerator().MoveNext();
                return (hasAtLeastOne == false) ^ this.IsInverted;
            }

            return true ^ this.IsInverted;
        }
    }
}