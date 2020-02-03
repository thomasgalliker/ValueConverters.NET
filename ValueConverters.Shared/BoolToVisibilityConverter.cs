#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

#if !XAMARIN
namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(Visibility))]
#endif
    public class BoolToVisibilityConverter : BoolToValueConverter<Visibility>
    {
        public BoolToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }
    }
}
#endif
