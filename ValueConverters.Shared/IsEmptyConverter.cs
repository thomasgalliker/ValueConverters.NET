using System.Globalization;
using System;
using System.Collections;

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class IsEmptyConverter : SingletonConverterBase<IsEmptyConverter>
    {
        public static readonly DependencyProperty IsInvertedProperty = DependencyProperty.Register(
            "IsInverted",
            typeof(bool),
            typeof(IsEmptyConverter),
            new PropertyMetadata(false));

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