

#if (NETFX || WINDOWS_PHONE)
using System.Windows.Media;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml.Media;
#endif

namespace ValueConverters
{
    public class BoolToBrushConverter : BoolToValueConverter<Brush>
    {
    }
}
