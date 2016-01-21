using System.Globalization;
using System;

#if NETFX || WINDOWS_PHONE
using System.Windows;
using System.Windows.Data;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace ValueConverters
{
    public class BoolToValueConverter<T> : ConverterBase
    {
        public static readonly DependencyProperty TrueValueProperty = DependencyProperty.Register(
            "TrueValue",
            typeof(T),
            typeof(BoolToValueConverter<T>),
            new PropertyMetadata(default(T)));

        public static readonly DependencyProperty FalseValueProperty = DependencyProperty.Register(
            "FalseValue",
            typeof(T),
            typeof(BoolToValueConverter<T>),
            new PropertyMetadata(default(T)));

        public T TrueValue
        {
            get { return (T)this.GetValue(TrueValueProperty); }
            set { this.SetValue(TrueValueProperty, value); }
        }

        public T FalseValue
        {
            get { return (T)this.GetValue(FalseValueProperty); }
            set { this.SetValue(FalseValueProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return this.FalseValue;
            }
            return (bool)value ? this.TrueValue : this.FalseValue;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(this.TrueValue);
        }
    }
}