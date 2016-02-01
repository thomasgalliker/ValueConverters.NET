using Xamarin.Forms;

namespace ValueConverters
{
    public class BoolToFontAttributesConverter : BoolToValueConverter<FontAttributes>
    {
        public BoolToFontAttributesConverter()
        {
            this.TrueValue = FontAttributes.Bold;
            this.FalseValue = FontAttributes.None;
        }
    }
}
