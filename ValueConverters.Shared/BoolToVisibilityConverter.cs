#if (NETFX || NET5_0_OR_GREATER)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

#if !XAMARIN
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