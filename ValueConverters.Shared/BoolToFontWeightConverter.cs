#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Text;
#endif

#if !XAMARIN
namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(FontWeight))]
#endif
    public class BoolToFontWeightConverter : BoolToValueConverter<FontWeight>
    {
        public BoolToFontWeightConverter()
        {
            this.TrueValue = FontWeights.Bold;
            this.FalseValue = FontWeights.Normal;
        }
    }
}
#endif
