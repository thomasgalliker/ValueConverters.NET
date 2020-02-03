#if (NETFX || WINDOWS_PHONE)
using System.Windows.Media;
#elif (NETFX_CORE)
using Windows.UI.Xaml.Media;
#endif

#if !XAMARIN
namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(Brush))]
#endif
    public class BoolToBrushConverter : BoolToValueConverter<Brush>
    {
    }
}
#endif
