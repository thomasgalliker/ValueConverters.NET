
#if (NETFX || NET5_0_OR_GREATER)
using System.Windows;
#elif (NETFX_CORE)
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
