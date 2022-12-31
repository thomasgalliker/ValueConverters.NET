#if (NETFX || NETWPF)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

#if NETFX || NETFX_CORE || NETWPF
namespace ValueConverters
{
    public class BoolToVisibilityConverter : BoolToValueConverter<Visibility>
    {
        public BoolToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }
    }
}
#endif