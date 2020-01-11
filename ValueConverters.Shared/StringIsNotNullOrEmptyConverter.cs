using System;
using System.Globalization;

#if XAMARIN
using Xamarin.Forms;
#endif

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
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
            IsInverted = true;
        }
    }

    public class StringIsNullOrEmptyConverter : SingletonConverterBase<StringIsNotNullOrEmptyConverter>
    {
#if XAMARIN
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
            if (IsInverted)
            {
                return !string.IsNullOrEmpty(value as string);
            }

            return string.IsNullOrEmpty(value as string);
        }
    }
}
