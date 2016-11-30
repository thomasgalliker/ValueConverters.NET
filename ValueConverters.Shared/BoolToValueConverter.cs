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
    public class BoolToValueConverter<T> : BoolToValueConverterBase<T, BoolToValueConverter<T>>
    {
#if XAMARIN
        public static readonly BindableProperty TrueValueProperty = BindableProperty.Create(
            "TrueValue",
            typeof(T),
            typeof(BoolToValueConverter<T>),
            default(T));

        public static readonly BindableProperty FalseValueProperty = BindableProperty.Create(
            "FalseValue",
            typeof(T),
            typeof(BoolToValueConverter<T>),
            default(T));

        public static readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
            "IsInverted",
            typeof(bool),
            typeof(BoolToValueConverter<T>),
            false);
#else
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
#endif

        public override T TrueValue
        {
            get { return (T)this.GetValue(TrueValueProperty); }
            set { this.SetValue(TrueValueProperty, value); }
        }

        public override T FalseValue
        {
            get { return (T)this.GetValue(FalseValueProperty); }
            set { this.SetValue(FalseValueProperty, value); }
        }

        public override bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }
    }
}
