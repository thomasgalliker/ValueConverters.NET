namespace ValueConverters
{
    /// <summary>
    /// EnumToBoolConverter can be used to bind to RadioButtons.
    /// </summary>
    // Source: http://stackoverflow.com/questions/397556/how-to-bind-radiobuttons-to-an-enum
    public class EnumToBoolConverter : SingletonConverterBase<EnumToBoolConverter>
    {
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter is not string parameterString)
            {
                return false;
            }

            var enumType = Nullable.GetUnderlyingType(value.GetType()) ?? value.GetType();

            if (!enumType.IsEnum || !Enum.IsDefined(enumType, value))
            {
                return UnsetValue;
            }

            var parameterValue = Enum.Parse(enumType, parameterString);
            return parameterValue.Equals(value);
        }

        protected override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not true || parameter is not string parameterString)
            {
                return Binding.DoNothing;
            }

            var enumType = Nullable.GetUnderlyingType(targetType) ?? targetType;
            return Enum.Parse(enumType, parameterString);
        }
    }
}