using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ValueConverters
{
    /// <summary>
    ///     Factory class.
    /// </summary>
    public static class EnumWrapper
    {
        /// <summary>
        ///     Creates a list of wrapped values of an enumeration.
        /// </summary>
        /// <typeparam name="TEnumType">Type of the enumeration.</typeparam>
        /// <returns>The wrapped enumeration values.</returns>
        public static IEnumerable<EnumWrapper<TEnumType>> CreateWrappers<TEnumType>()
            where TEnumType : IConvertible
        {
            FieldInfo[] infos = typeof (TEnumType).GetFields(BindingFlags.Public | BindingFlags.Static);
            return infos.Select(x => new EnumWrapper<TEnumType>((TEnumType) x.GetValue(null)));
        }

        /// <summary>
        ///     Create the wrapped value of an enumeration value.
        /// </summary>
        /// <typeparam name="TEnumType">Type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="nameStyle">The name (short or long) to be considered from the attribute</param>
        /// <returns>The wrapped value.</returns>
        public static EnumWrapper<TEnumType> CreateWrapper<TEnumType>(TEnumType value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName) where TEnumType : IConvertible
        {
            return new EnumWrapper<TEnumType>(value, nameStyle);
        }

        /// <summary>
        ///     Create the wrapped value of an enumeration value.
        /// </summary>
        /// <typeparam name="TEnumType">Type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The wrapped value.</returns>
        public static EnumWrapper<TEnumType> CreateWrapper<TEnumType>(int value) where TEnumType : IConvertible
        {
            return new EnumWrapper<TEnumType>((TEnumType) ((object) value));
        }
    }

    /// <summary>
    ///     Wrapper for binding directly.
    /// </summary>
    /// <typeparam name="TEnumType">
    ///     Type of the enumeration.
    /// </typeparam>
    public class EnumWrapper<TEnumType> : IEquatable<EnumWrapper<TEnumType>>
        where TEnumType : IConvertible
    {
        private readonly TEnumType value;
        private readonly EnumWrapperConverterNameStyle nameStyle;

        public EnumWrapper(TEnumType value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            this.value = value;
            this.nameStyle = nameStyle;
        }
        /// <summary>
        ///     The Value.
        /// </summary>
        public TEnumType Value
        {
            get { return this.value; }
        }

        /// <summary>
        ///     Checks if some objects are equal.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>True or false.</returns>
        public bool Equals(EnumWrapper<TEnumType> other)
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
        ///     Implicit back conversion to the enumeration.
        /// </summary>
        /// <param name="enumToConvert">The enumeration to convert.</param>
        /// <returns>The converted value.</returns>
        public static implicit operator TEnumType(EnumWrapper<TEnumType> enumToConvert)
        {
            return enumToConvert.value;
        }

        /// <summary>
        ///     Implicit back conversion to the enumeration.
        /// </summary>
        /// <param name="enumToConvert">The enumeration to convert.</param>
        /// <returns>The converted value.</returns>
        public static implicit operator int(EnumWrapper<TEnumType> enumToConvert)
        {
            return enumToConvert.value.ToInt32(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True or false.</returns>
        public static bool operator ==(EnumWrapper<TEnumType> left, EnumWrapper<TEnumType> right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Not equal comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True or false.</returns>
        public static bool operator !=(EnumWrapper<TEnumType> left, EnumWrapper<TEnumType> right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Implicit to string conversion.
        /// </summary>
        /// <returns>Value converted to a string.</returns>
        public override string ToString()
        {
            Type enumType = typeof (TEnumType);
            FieldInfo[] infos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

            IEnumerable<FieldInfo> info = infos.Where(x => x.GetValue(null).Equals(this.value));

            if (info.Any())
            {
                return info.Select(i =>
                {
                    var attribute =
                        (DisplayAttribute)
                            Attribute.GetCustomAttribute(
                                i, typeof (DisplayAttribute));

                    if (attribute != null)
                    {
                        return (this.nameStyle == EnumWrapperConverterNameStyle.LongName) ? 
                            attribute.GetName() : 
                            attribute.GetShortName();
                    }
                    return this.Value.ToString(CultureInfo.InvariantCulture);
                }).Single();
            }

            return string.Empty;
        }

        /// <summary>
        ///     Checks if some objects are equal.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>True or false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (EnumWrapper<TEnumType>))
            {
                return false;
            }
            return this.Equals((EnumWrapper<TEnumType>) obj);
        }

        /// <summary>
        ///     The hash code of the object.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}