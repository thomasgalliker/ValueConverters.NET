#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Text;
#endif

#if !XAMARIN
namespace ValueConverters
{
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