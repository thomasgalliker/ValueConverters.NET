using System;
using System.Globalization;

using Xamarin.Forms;

namespace ValueConverters
{
    public class BoolToValueConverter<T> : BoolToValueConverterBase<T>
    {
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