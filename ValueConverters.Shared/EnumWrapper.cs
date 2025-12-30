using ValueConverters.Annotations;

namespace ValueConverters
{
    public static class EnumWrapper
    {
        /// <summary>
        /// Creates a list of wrapped values of an enumeration.
        /// </summary>
        /// <typeparam name="TEnumType">Type of the enumeration.</typeparam>
        /// <returns>The wrapped enumeration values.</returns>
        public static IEnumerable<EnumWrapper<TEnumType>> CreateWrappers<TEnumType>()
        {
            var allEnums = Enum.GetValues(typeof(TEnumType)).OfType<TEnumType>();
            return allEnums.Select(x => new EnumWrapper<TEnumType>(x));
        }

        /// <summary>
        /// Create the wrapped value of an enumeration value.
        /// </summary>
        /// <typeparam name="TEnumType">Type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="nameStyle">The name (short or long) to be considered from the attribute</param>
        /// <returns>The wrapped value.</returns>
        public static EnumWrapper<TEnumType> CreateWrapper<TEnumType>(TEnumType value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            return new EnumWrapper<TEnumType>(value, nameStyle);
        }

        /// <summary>
        /// Create the wrapped value of an enumeration value.
        /// </summary>
        /// <typeparam name="TEnumType">Type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The wrapped value.</returns>
        public static EnumWrapper<TEnumType> CreateWrapper<TEnumType>(int value)
        {
            return new EnumWrapper<TEnumType>((TEnumType)(object)value);
        }
    }

    public class EnumWrapper<TEnumType> : BindableBase, IEquatable<EnumWrapper<TEnumType>>
    {
        private readonly TEnumType value;
        private readonly EnumWrapperConverterNameStyle nameStyle;

        public EnumWrapper(TEnumType value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            this.value = value;
            this.nameStyle = nameStyle;
        }

        public TEnumType Value => this.value;

        /// <summary>
        /// Use LocalizedValue to bind UI elements to.
        /// To enforce a refresh of LocalizedValue property (e.g. when you change the UI culture at runtime)
        /// just call the <code>Refresh</code> method.
        /// </summary>
        public string? LocalizedValue => this.ToString();

        /// <summary>
        /// Implicit to string conversion.
        /// </summary>
        /// <returns>Value converted to a localized string.</returns>
        public override string? ToString()
        {
            if (this.value is Enum enumValue)
            {
                return EnumDisplayResolver.GetDisplayName(enumValue, this.nameStyle);
            }

            return this.value?.ToString();
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

            var enumWrapper = obj as EnumWrapper<TEnumType>;
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
        public bool Equals(EnumWrapper<TEnumType>? other)
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
        public static implicit operator TEnumType(EnumWrapper<TEnumType> enumToConvert)
        {
            return enumToConvert.value;
        }

        /// <summary>
        /// Implicit back conversion to the enumeration.
        /// </summary>
        /// <param name="enumToConvert">The enumeration to convert.</param>
        /// <returns>The converted value.</returns>
        public static implicit operator int(EnumWrapper<TEnumType> enumToConvert)
        {
            return Convert.ToInt32(enumToConvert.value);
        }

        /// <summary>
        /// Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True or false.</returns>
        public static bool operator ==(EnumWrapper<TEnumType>? left, EnumWrapper<TEnumType>? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not equal comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True or false.</returns>
        public static bool operator !=(EnumWrapper<TEnumType>? left, EnumWrapper<TEnumType>? right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// The hash code of the object.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return this.Value?.GetHashCode() ?? 0;
        }

        public void Refresh()
        {
            this.RaisePropertyChanged(nameof(this.Value));
            this.RaisePropertyChanged(nameof(this.LocalizedValue));
        }
    }
}