#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#elif (XAMARIN)
using Xamarin.Forms;
#endif

namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(Thickness))]
#endif
    public class BoolToThicknessConverter : BoolToValueConverter<Thickness>
    {
    }
}
