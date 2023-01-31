#if XAMARIN
using Xamarin.Forms;
#elif MAUI
using Microsoft.Maui;
#endif

namespace ValueConverters
{
    /// <summary>
    /// Converts a bool value to ImageSource.
    /// </summary>
    public class BoolToImageSourceConverter : BoolToValueConverter<ImageSource>
    {
    }
}
