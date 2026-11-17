namespace ValueConverters
{
    /// <summary>
    /// Changes capitalization of a string.
    /// </summary>
    /// <example>
    /// Convert a string to lower case:
    /// Text="{Binding Text, Converter={StaticResource StringCaseConverter}, ConverterParameter=L}}"
    /// 
    /// Convert a string to upper case:
    /// Text="{Binding Text, Converter={StaticResource StringCaseConverter}, ConverterParameter=U}}"
    /// 
    /// Convert a string to title case:
    /// Text="{Binding Text, Converter={StaticResource StringCaseConverter}, ConverterParameter=T}}"
    /// </example>
    public class StringCaseConverter : SingletonConverterBase<StringCaseConverter>
    {
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                var stringParameter = $"{parameter}";

                switch (stringParameter)
                {
                    case "U":
                    case "u":
                        return culture.TextInfo.ToUpper(stringValue);
                    case "L":
                    case "l":
                        return culture.TextInfo.ToLower(stringValue);
                    case "T":
                    case "t":
                        return culture.TextInfo.ToTitleCase(stringValue);
                    default:
                        throw new ArgumentException($"Parameter '{stringParameter}' is not valid", nameof(parameter));
                }
            }

            return UnsetValue;
        }
    }
}
