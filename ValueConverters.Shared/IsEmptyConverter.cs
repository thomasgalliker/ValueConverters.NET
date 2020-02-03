using System.Globalization;
using System;
using System.Collections;

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
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(IEnumerable), typeof(bool))]
#endif
    public class IsEmptyConverter : SingletonConverterBase<IsEmptyConverter>
    {
#if XAMARIN
        public static readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
            "IsInverted",
            typeof(bool),
            typeof(IsEmptyConverter),
            default(bool));
#else
        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            "IsInverted",
            typeof(bool),
            typeof(IsEmptyConverter),
            new PropertyMetadata(false));
#endif

        public bool IsInverted
        {
            get { return (bool)this.GetValue(IsInvertedProperty); }
            set { this.SetValue(IsInvertedProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = value as IEnumerable;
            if (enumerable != null)
            {
                var hasAtLeastOne = enumerable.GetEnumerator().MoveNext();
                return (hasAtLeastOne == false) ^ this.IsInverted;
            }

            return true ^ this.IsInverted;
        }
    }
}
