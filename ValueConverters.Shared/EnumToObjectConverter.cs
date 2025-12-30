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
    /// <code>
    /// <![CDATA[
    /// <example>
    ///    <ResourceDictionary>
    ///      <BitmapImage x:Key="Off" UriSource="/Resources/Images/stop.png" />
    ///      <BitmapImage x:Key="On" UriSource="/Resources/Images/play.png" />
    ///      <BitmapImage x:Key="Maybe" UriSource="/Resources/Images/pause.png" />
    ///    </ResourceDictionary>
    /// </example>
    /// ]]>
    /// </code>
    /// Source: http://stackoverflow.com/questions/2787725/how-to-display-different-enum-icons-using-xaml-only
    /// </summary>
    public class EnumToObjectConverter : StringToObjectConverter
    {
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return UnsetValue;
            }

            var type = value.GetType();
            var key = Enum.GetName(type, value);
            return base.Convert(key, targetType, parameter, culture);
        }
    }
}
