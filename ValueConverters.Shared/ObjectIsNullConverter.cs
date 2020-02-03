using System.Globalization;
using System;

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
    [Obsolete("NullToBoolConverter has been renamed to ObjectIsNullConverter. Please use ObjectIsNullConverter. NullToBoolConverter will be removed in future releases.")]
    public class NullToBoolConverter : ObjectIsNullConverter
    {
    }

    public class ObjectIsNullConverter : SingletonConverterBase<ObjectIsNullConverter>
    {
#if XAMARIN
        public static readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
            nameof(IsInverted),
            typeof(bool),
            typeof(NullToBoolConverter),
            default(bool));
#else
        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            nameof(IsInverted),
            typeof(bool),
            typeof(ObjectIsNullConverter),
            new PropertyMetadata(false));
#endif

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ^ this.IsInverted;
        }
    }
}
