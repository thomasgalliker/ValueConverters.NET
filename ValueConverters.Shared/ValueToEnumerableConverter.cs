using System;
using System.Globalization;

namespace ValueConverters
{
    /// <summary>
    /// Converts given value into an IEnumerable containing the value as single object.
    /// This is particularly useful if you have a control which accepts IEnumerable but you only want to bind a single value.
    /// </summary>
    public class ValueToEnumerableConverter : SingletonConverterBase<ValueToEnumerableConverter>
    {
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return new object[1] { value };
            }

            return UnsetValue;
        }
    }
}
