using System;
using System.Globalization;

#if (NETFX || WINDOWS_PHONE)
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
#endif

namespace ValueConverters
{
    public abstract class ReversibleValueToBoolConverterBase<T, TConverter> 
        : ValueToBoolConverterBase<T, TConverter>
        where TConverter : new()
    {
        public abstract T FalseValue { get; set; }

        public bool BaseOnFalseValue
        {
            get
            {
                return (bool)this.GetValue(BaseOnFalseValueProperty);
            }
            set
            {
                this.SetValue(BaseOnFalseValueProperty, value);
            }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!this.BaseOnFalseValue)
            {
                return base.Convert(value, targetType, parameter, culture);
            }
            else
            {
                T falseValue = this.FalseValue;
                return !Equals(value, falseValue) ^ this.IsInverted;
            }
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true.Equals(value) ^ this.IsInverted ? this.TrueValue : this.FalseValue;
        }

        public static readonly Property BaseOnFalseValueProperty = PropertyHelper.Create<bool, ValueToBoolConverterBase<T, TConverter>>(nameof(BaseOnFalseValueProperty));
    }
}