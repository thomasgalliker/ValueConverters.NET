using System.Globalization;

namespace ValueConverters
{
    /// <summary>
    /// Converts a byte[] to an ImageSource.
    /// </summary>
    public class ByteToImageSourceConverter : ConverterBase
    {
        /// <inheritdoc/>
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[] image))
            {
                return UnsetValue;
            }

            return ImageSource.FromStream(() => new MemoryStream(image));
        }
    }
}
