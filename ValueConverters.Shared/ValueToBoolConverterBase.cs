using System;
using System.Globalization;

#if (NETFX || NETWPF)
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

#elif (MAUI)
using Microsoft.Maui;
using Property = Microsoft.Maui.Controls.BindableProperty;
#endif

namespace ValueConverters
{
    public abstract class ValueToBoolConverterBase<T, TConverter> : ConverterBase
        where TConverter : new()
    {
        public abstract T TrueValue { get; set; }

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var trueValue = this.TrueValue;
            return Equals(value, trueValue) ^ this.IsInverted;
        }

        public static readonly Property IsInvertedProperty = PropertyHelper.Create<bool, ValueToBoolConverterBase<T, TConverter>>(nameof(IsInverted));
    }
}
