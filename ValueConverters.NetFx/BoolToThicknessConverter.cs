
#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class BoolToThicknessConverter : BoolToValueConverter<Thickness>
    {
    }
}
