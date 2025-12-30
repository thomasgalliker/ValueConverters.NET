using Microsoft.Maui.Converters;

namespace ValueConverters
{
    /// <summary>
    /// Converts <see cref="Thickness"/> to string (and back).
    /// </summary>
    public class StringToThicknessConverter : IValueConverter
    {
        private static readonly ThicknessTypeConverter ThicknessTypeConverter = new ThicknessTypeConverter();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        private static object? Convert(object? value)
        {
            object? convertedValue = null;

            if (value is string stringValue)
            {
                try
                {
                    convertedValue = ThicknessTypeConverter.ConvertFromString(stringValue);
                }
                catch
                {
                    convertedValue = default(Thickness);
                }
            }

            if (value is Thickness thickness)
            {
                try
                {
                    convertedValue = ThicknessTypeConverter.ConvertToString(thickness);
                }
                catch
                {
                    convertedValue = null;
                }
            }

            return convertedValue;
        }
    }
}