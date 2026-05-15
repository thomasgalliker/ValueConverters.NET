using ValueConverters.Annotations;

namespace ValueConverters
{
    public static class EnumWrapper
    {
        /// <summary>
        /// Creates a list of wrapped values of an enumeration.
        /// </summary>
        /// <typeparam name="TEnum">Type of the enumeration.</typeparam>
        /// <returns>The wrapped enumeration values.</returns>
        public static IEnumerable<EnumWrapper<TEnum>> CreateWrappers<TEnum>()
             where TEnum : struct, Enum
        {
            var allEnums = Enum.GetValues(typeof(TEnum)).OfType<TEnum>();
            return allEnums.Select(x => new EnumWrapper<TEnum>(x));
        }

        /// <summary>
        /// Create the wrapped value of an enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">Type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="nameStyle">The name (short or long) to be considered from the attribute</param>
        /// <returns>The wrapped value.</returns>
        public static EnumWrapper<TEnum> CreateWrapper<TEnum>(TEnum value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
            where TEnum : struct, Enum
        {
            return new EnumWrapper<TEnum>(value, nameStyle);
        }

        /// <summary>
        /// Create the wrapped value of an enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">Type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The wrapped value.</returns>
        public static EnumWrapper<TEnum> CreateWrapper<TEnum>(int value)
             where TEnum : struct, Enum
        {
            return new EnumWrapper<TEnum>((TEnum)(object)value);
        }
    }

    public class EnumWrapper<TEnum> : BindableBase, IEquatable<EnumWrapper<TEnum>>
        where TEnum : struct, Enum
    {
        private readonly TEnum value;
        private readonly EnumWrapperConverterNameStyle nameStyle;

        public EnumWrapper(TEnum value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            this.value = value;
            this.nameStyle = nameStyle;
        }

        public TEnum Value => this.value;

        /// <summary>
        /// Use LocalizedValue to bind UI elements to.
        /// To enforce a refresh of LocalizedValue property (e.g. when you change the UI culture at runtime)
        /// just call the <code>Refresh</code> method.
        /// </summary>
        public string LocalizedValue => this.ToString();

        /// <summary>
        /// Implicit to string conversion.
        /// </summary>
        /// <returns>Value converted to a localized string.</returns>
        public override string ToString()
        {
            if (this.value is Enum enumValue)
            {
                return DisplayAttribute.GetDisplayName(enumValue, this.nameStyle);
            }

            return $"{this.value}";
        }

        /// <summary>
        /// Checks if some objects are equal.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>True or false.</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var enumWrapper = obj as EnumWrapper<TEnum>;
            if (enumWrapper == null)
            {
                return false;
            }

            return this.Equals(enumWrapper);
        }

        /// <summary>
        /// Checks if some objects are equal.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>True or false.</returns>
        public bool Equals(EnumWrapper<TEnum>? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Value, this.Value);
        }

        /// <summary>
        /// Implicit back conversion to the enumeration.
        /// </summary>
        /// <param name="enumToConvert">The enumeration to convert.</param>
        /// <returns>The converted value.</returns>
        public static implicit operator TEnum(EnumWrapper<TEnum> enumToConvert)
        {
            return enumToConvert.value;
        }

        /// <summary>
        /// Implicit back conversion to the enumeration.
        /// </summary>
        /// <param name="enumToConvert">The enumeration to convert.</param>
        /// <returns>The converted value.</returns>
        public static implicit operator int(EnumWrapper<TEnum> enumToConvert)
        {
            return Convert.ToInt32(enumToConvert.value);
        }

        /// <summary>
        /// Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True or false.</returns>
        public static bool operator ==(EnumWrapper<TEnum>? left, EnumWrapper<TEnum>? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not equal comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True or false.</returns>
        public static bool operator !=(EnumWrapper<TEnum>? left, EnumWrapper<TEnum>? right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// The hash code of the object.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public void Refresh()
        {
            this.RaisePropertyChanged(nameof(this.Value));
            this.RaisePropertyChanged(nameof(this.LocalizedValue));
        }
    }
}
