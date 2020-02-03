#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

#if !XAMARIN
namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(Visibility), typeof(Visibility))]
#endif
    public class VisibilityInverter : BoolToValueConverter<Visibility>
    {
        public VisibilityInverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
            this.IsInverted = true;
        }
    }
}
#endif
