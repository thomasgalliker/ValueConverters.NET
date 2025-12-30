using System.Globalization;

namespace ValueConverters
{
    public class ByteArrayToImageSourceConverter : SingletonConverterBase<ByteArrayToImageSourceConverter>
    {
        /// <summary>
        /// Converts the incoming value from <see cref="byte"/>[] and returns the object of a type <see cref="ImageSource"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type of the binding target property. This is not implemented.</param>
        /// <param name="parameter">Additional parameter for the converter to handle. This is not implemented.</param>
        /// <param name="culture">The culture to use in the converter. This is not implemented.</param>
        /// <returns>An object of type <see cref="ImageSource"/>.</returns>
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is byte[] imageBytes)
            {
                return ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }

            return UnsetValue;
        }
    }
}
