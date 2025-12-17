using System.Globalization;
using System;
using System.Collections;

#if (NETFX || NETWPF)
using System.Windows;

#elif (NETFX_CORE)
using Windows.UI.Xaml;

#elif XAMARIN
using Xamarin.Forms;
#endif

namespace ValueConverters
{
    public class NullToBoolConverter : SingletonConverterBase<NullToBoolConverter>
    {
#if XAMARIN || MAUI
        public static readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
            nameof(IsInverted),
            typeof(bool),
            typeof(NullToBoolConverter),
            default(bool));
#else
        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            nameof(IsInverted),
            typeof(bool),
            typeof(NullToBoolConverter),
            new PropertyMetadata(false));
#endif

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value == null ^ this.IsInverted;
        }
    }
}