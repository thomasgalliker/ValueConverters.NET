
#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
#elif (XAMARIN)
using Xamarin.Forms;
#endif

namespace ValueConverters
{
    public class BoolToThicknessConverter : BoolToValueConverter<Thickness>
    {
    }
}
