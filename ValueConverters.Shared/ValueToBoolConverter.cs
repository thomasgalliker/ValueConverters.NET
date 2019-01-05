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
    public class ValueToBoolConverter<T> : ReversibleValueToBoolConverterBase<T, ValueToBoolConverter<T>>
    {
        public override T TrueValue {
            get
            {
                return (T)this.GetValue(TrueValueProperty);
            }
            set
            {
                this.SetValue(TrueValueProperty, value);
            }
        }

        public static readonly Property TrueValueProperty =
            PropertyHelper.Create<T, ValueToBoolConverter<T>>(nameof(TrueValue));

        public override T FalseValue {
            get
            {
                return (T)this.GetValue(FalseValueProperty);
            }
            set
            {
                this.SetValue(FalseValueProperty, value);
            }
        }

        public static readonly Property FalseValueProperty =
            PropertyHelper.Create<T, ValueToBoolConverter<T>>(nameof(FalseValue));
    }

    public class ValueToBoolConverter : ValueToBoolConverter<object>
    {
    }
}
