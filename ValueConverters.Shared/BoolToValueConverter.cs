#if (NETFX || NETWPF)
using System.Windows;
using System.Windows.Data;

#elif NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

#elif XAMARIN
using Xamarin.Forms;

#elif MAUI
using Microsoft.Maui;
#endif

namespace ValueConverters
{
    public class BoolToValueConverter<T> : BoolToValueConverterBase<T, BoolToValueConverter<T>>
    {
#if XAMARIN || MAUI
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
            get => (T)this.GetValue(TrueValueProperty);
            set => this.SetValue(TrueValueProperty, value);
        }

        public override T FalseValue
        {
            get => (T)this.GetValue(FalseValueProperty);
            set => this.SetValue(FalseValueProperty, value);
        }

        public override bool IsInverted
        {
            get => (bool)this.GetValue(IsInvertedProperty);
            set => this.SetValue(IsInvertedProperty, value);
        }
    }
}
