using System.Globalization;

#if NETFX || NET5_0_OR_GREATER
using System.Windows.Data;
#elif (NETFX_CORE)
using Windows.UI.Xaml.Data;
#elif (XAMARIN)
using Xamarin.Forms;
#endif

namespace ValueConverters
{
    public enum PreferredCulture
    {
        /// <summary>
        /// Uses the default culture provided by <seealso cref="IValueConverter"/>.
        /// </summary>
        ConverterCulture,

        /// <summary>
        /// Overrides the default converter culture with <seealso cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        CurrentCulture,

        /// <summary>
        /// Overrides the default converter culture with <seealso cref="CultureInfo.CurrentUICulture"/>.
        /// </summary>
        CurrentUICulture,
    }
}
