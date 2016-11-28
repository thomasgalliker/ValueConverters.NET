

#if (NETFX || WINDOWS_PHONE)
using System.Windows.Media;
#elif (NETFX_CORE)
using Windows.UI.Xaml.Media;
#endif

namespace ValueConverters
{
    public class BoolToBrushConverter : BoolToValueConverter<Brush>
    {
    }
}
