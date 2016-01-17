#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Text;
#endif

namespace ValueConverters
{
    public class BoolToFontWeightConverter : BoolToValueConverter<FontWeight>
    {
    }
}
