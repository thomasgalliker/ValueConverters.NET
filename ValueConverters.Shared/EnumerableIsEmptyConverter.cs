using System.Globalization;
using System;
using System.Collections;

#if XAMARIN
using Xamarin.Forms;
#endif

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
#endif

namespace ValueConverters
{
    [Obsolete("IsEmptyConverter has been renamed to EnumerableIsEmptyConverter. Please use EnumerableIsEmptyConverter. IsEmptyConverter will be removed in future releases.")]
    public class IsEmptyConverter : EnumerableIsEmptyConverter
    {
    }

    public class EnumerableIsEmptyConverter : SingletonConverterBase<EnumerableIsEmptyConverter>
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
            typeof(EnumerableIsEmptyConverter),
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
