#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class VisibilityInverter : BoolToValueConverter<Visibility>
    {
        public VisibilityInverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
            this.IsInverted = true;
        }
    }
}