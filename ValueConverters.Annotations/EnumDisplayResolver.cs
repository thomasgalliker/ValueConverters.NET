using System.Globalization;

namespace ValueConverters.Annotations
{
    public static class EnumDisplayResolver
    {
        public static string GetDisplayName(Enum value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName, CultureInfo? culture = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);

            if (name == null)
            {
                return value.ToString();
            }

            var field = enumType.GetField(name);
            if (field == null)
            {
                return name;
            }

            var displayAttribute = field
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .FirstOrDefault();

            if (displayAttribute == null)
            {
                return name;
            }

            return nameStyle == EnumWrapperConverterNameStyle.LongName
                ? displayAttribute.GetName(culture) ?? name
                : displayAttribute.GetShortName(culture) ?? name;
        }
    }
}
