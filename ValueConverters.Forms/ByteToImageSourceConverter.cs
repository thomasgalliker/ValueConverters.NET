using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace ValueConverters
{
    public class ByteToImageSourceConverter : ConverterBase
    {
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
