using System.Globalization;
using System;

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class BoolToValueConverter<T> : BoolToValueConverterBase<T>
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