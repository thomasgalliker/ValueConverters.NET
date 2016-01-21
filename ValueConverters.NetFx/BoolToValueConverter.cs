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

        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            "IsInverted",
            typeof(bool),
            typeof(BoolToValueConverter<T>),
            new PropertyMetadata(false));

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

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var returnValue = this.FalseValue;

            if (value != null)
            {
                if (this.IsInverted)
                {
                    returnValue = (bool)value ? this.FalseValue : this.TrueValue;
                }
                else
                {
                    returnValue = (bool)value ? this.TrueValue : this.FalseValue;
                }
            }

            return returnValue;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(this.TrueValue);
        }
    }
}