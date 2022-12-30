using System;
using System.Globalization;

#if (NETFX || NETWPF)
using System.Windows;
using System.Windows.Data;

#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

#elif XAMARIN
using Xamarin.Forms;

#elif MAUI
using Microsoft.Maui;
#endif

namespace ValueConverters
{
    [Obsolete("StringLengthToBoolConverter has been renamed to StringIsNotNullOrEmptyConverter. Please use StringIsNotNullOrEmptyConverter. StringLengthToBoolConverter will be removed in future releases.")]
    public class StringLengthToBoolConverter : StringIsNotNullOrEmptyConverter
    {
    }

    public class StringIsNotNullOrEmptyConverter : StringIsNullOrEmptyConverter
    {
        public StringIsNotNullOrEmptyConverter()
        {
            this.IsInverted = true;
        }
    }

    public class StringIsNullOrEmptyConverter : SingletonConverterBase<StringIsNotNullOrEmptyConverter>
    {
#if XAMARIN || MAUI
        public static readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
            nameof(IsInverted),
            typeof(bool),
            typeof(StringIsNullOrEmptyConverter),
            false);
#else
        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            nameof(IsInverted),
            typeof(bool),
            typeof(StringIsNullOrEmptyConverter),
            new PropertyMetadata(false));
#endif

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (this.IsInverted)
            {
                return !string.IsNullOrEmpty(value as string);
            }

            return string.IsNullOrEmpty(value as string);
        }
    }
}
