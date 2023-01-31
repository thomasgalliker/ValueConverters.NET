
#if (NETFX || NETWPF)
using System.Windows.Media;
#elif (NETFX_CORE)
using Windows.UI.Xaml.Media;
#endif

#if NETFX || NETFX_CORE || NETWPF
namespace ValueConverters
{
    public class BoolToBrushConverter : BoolToValueConverter<Brush>
    {
    }
}
#endif