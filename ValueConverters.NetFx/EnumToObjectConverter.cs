using System;
using System.Globalization;

#if (NETFX || WINDOWS_PHONE)
using System.Windows;
using System.Windows.Markup;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;
#elif (XAMARIN)
using Xamarin.Forms;
#endif

namespace ValueConverters
{
    /// <summary>
    /// EnumToObjectConverter can be used to select different resources based on given enum name.
    /// This can be particularly useful if an enum needs to represent an image on the user interface.
    /// 
    /// Use the Items property to create a ResourceDictionary which contains object-to-enum-name mappings.
    /// Each defined object must have an x:Key which maps to the particular enum name.
    /// 
    /// Check out following example:
    /// <example>
    ///    <ResourceDictionary>
    ///      <BitmapImage x:Key="Off" UriSource="/Resources/Images/stop.png" />
    ///      <BitmapImage x:Key="On" UriSource="/Resources/Images/play.png" />
    ///      <BitmapImage x:Key="Maybe" UriSource="/Resources/Images/pause.png" />
    ///    </ResourceDictionary>
    /// </example>
    /// Source: http://stackoverflow.com/questions/2787725/how-to-display-different-enum-icons-using-xaml-only
    /// </summary>
#if (NETFX || WINDOWS_PHONE)
    [ContentProperty("Items")]
#elif (NETFX_CORE)
    [ContentProperty(Name = "Items")]
#endif
    public class EnumToObjectConverter : ConverterBase
    {
        public ResourceDictionary Items { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return UnsetValue;
            }

            string key = Enum.GetName(value.GetType(), value);
            if (this.Items != null && ContainsKey(this.Items, key))
            {
                return this.Items[key];
            }

            return UnsetValue;
        }

#if (NETFX || WINDOWS_PHONE)
        private static bool ContainsKey(ResourceDictionary dict, string key)
        {
            return dict.Contains(key);
        }
#elif (NETFX_CORE || XAMARIN)
        private static bool ContainsKey(ResourceDictionary dict, string key)
        {
            return dict.ContainsKey(key);
        }
#endif
    }
}
