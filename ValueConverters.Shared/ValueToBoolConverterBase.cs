using System;
using System.Globalization;

#if XAMARIN
using Xamarin.Forms;
using Property = Xamarin.Forms.BindableProperty;
#else
using Property = System.Windows.DependencyProperty;
#endif

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public abstract class ValueToBoolConverterBase<T, TConverter> : ConverterBase
        where TConverter: new()
    {
        public abstract T TrueValue { get; set; }

        public bool IsInverted {
            get => (bool)this.GetValue(IsInvertedProperty);
            set => this.SetValue(IsInvertedProperty, value);
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            T trueValue = this.TrueValue;
            return object.Equals(value, trueValue) ^ this.IsInverted;
        }

        public static readonly Property IsInvertedProperty =
            PropertyHelper.Create<bool, ValueToBoolConverterBase<T,TConverter>>(nameof(IsInverted));
    }
}
