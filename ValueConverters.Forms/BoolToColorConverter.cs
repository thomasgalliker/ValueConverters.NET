using Xamarin.Forms;

namespace ValueConverters
{
    public class BoolToColorConverter : BoolToValueConverter<Color>
    {
        public BoolToColorConverter()
        {
            this.TrueValue = Color.Accent;
            this.FalseValue = Color.Default;
        }
    }
}
