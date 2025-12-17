namespace ValueConverters
{
    /// <summary>
    /// Converts a bool value to FontAttributes.
    /// </summary>
    /// <remarks>
    /// By default, TrueValue is FontAttributes.Bold, FalseValue is FontAttributes.None.
    /// </remarks>
    public class BoolToFontAttributesConverter : BoolToValueConverter<FontAttributes>
    {
        public BoolToFontAttributesConverter()
        {
            this.TrueValue = FontAttributes.Bold;
            this.FalseValue = FontAttributes.None;
        }
    }
}
