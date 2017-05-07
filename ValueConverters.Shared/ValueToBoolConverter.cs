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
    public class ValueToBoolConverter<T> : ValueToBoolConverterBase<T, ValueToBoolConverter<T>>
    {
        public override T TrueValue {
            get => (T)this.GetValue(TrueValueProperty);
            set => this.SetValue(TrueValueProperty, value);
        }

        public static readonly Property TrueValueProperty =
            PropertyHelper.Create<T, ValueToBoolConverter<T>>(nameof(TrueValue));
    }

    public class ValueToBoolConverter: ValueToBoolConverter<object> { }
}
