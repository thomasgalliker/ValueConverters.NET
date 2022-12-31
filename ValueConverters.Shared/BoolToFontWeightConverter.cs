
#if (NETFX || NETWPF)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Text;
#endif

#if NETFX || NETWPF || NETFX_CORE
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