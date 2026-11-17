#if NETFX || NETWPF
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