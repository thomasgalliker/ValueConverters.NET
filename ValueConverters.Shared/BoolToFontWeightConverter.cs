#if (NETFX || WINDOWS_PHONE)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Text;
#endif

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
