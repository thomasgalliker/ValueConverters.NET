using Microsoft.Maui.Graphics;

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
            this.TrueValue = Colors.Black;
            this.FalseValue = Colors.White;
        }
    }
}
