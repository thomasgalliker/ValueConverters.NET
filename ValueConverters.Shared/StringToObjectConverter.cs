namespace ValueConverters
{
    /// <summary>
    /// StringToObjectConverter can be used to select different resources based on given string name.
    /// This can be particularly useful if a string key needs to represent an image on the user interface.
    ///
    /// Use the Items property to create a ResourceDictionary which contains object-to-string-name mappings.
    ///
    /// Check out the following example:
    /// <example>
    /// <code>
    /// <![CDATA[
    /// <ResourceDictionary>
    ///   <BitmapImage x:Key="Off" UriSource="/Resources/Images/stop.png" />
    ///   <BitmapImage x:Key="On" UriSource="/Resources/Images/play.png" />
    ///   <BitmapImage x:Key="Maybe" UriSource="/Resources/Images/pause.png" />
    /// </ResourceDictionary>
    /// ]]>
    /// </code>
    /// </example>
    /// Source: http://stackoverflow.com/questions/2787725/how-to-display-different-enum-icons-using-xaml-only
    /// </summary>
    [ContentProperty(nameof(Items))]
    public class StringToObjectConverter : SingletonConverterBase<StringToObjectConverter>
    {
        public ResourceDictionary? Items { get; set; }

        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string key)
            {
                if (this.Items != null && ContainsKey(this.Items, key))
                {
                    return this.Items[key];
                }
            }

            return UnsetValue;
        }

#if NETFX || NETWPF
        private static bool ContainsKey(ResourceDictionary dict, string key)
        {
            return dict.Contains(key);
        }
#elif MAUI
        private static bool ContainsKey(ResourceDictionary dict, string key)
        {
            return dict.ContainsKey(key);
        }
#endif
    }
}
