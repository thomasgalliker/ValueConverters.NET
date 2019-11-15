using System;
using System.Globalization;

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
    /// </example>
    public class StringCaseConverter : SingletonConverterBase<StringCaseConverter>
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = $"{value}";
            var stringParameter = $"{parameter}";

            if (string.Equals(stringParameter, "U", StringComparison.CurrentCultureIgnoreCase))
            {
                return stringValue.ToUpper(culture);
            }
            
            if (string.Equals(stringParameter, "L", StringComparison.CurrentCultureIgnoreCase))
            {
                return stringValue.ToLower(culture);
            }

            return stringValue;
        }
    }
}
