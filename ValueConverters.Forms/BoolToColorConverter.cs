using Xamarin.Forms;

namespace ValueConverters
{
    /// <summary>
    /// Converts a bool value to Color.
    /// </summary>
    /// <remarks>
    /// By default, TrueValue is Color.Accent, FalseValue is Color.Default.
    /// </remarks>
    public class BoolToColorConverter : BoolToValueConverter<Color>
    {
        public BoolToColorConverter()
        {
            this.TrueValue = Color.Accent;
            this.FalseValue = Color.Default;
        }
    }
}
