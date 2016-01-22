#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Text;
#endif

namespace ValueConverters
{
    public class BoolToFontWeightConverter : BoolToValueConverter<FontWeight>
    {
    }
}
