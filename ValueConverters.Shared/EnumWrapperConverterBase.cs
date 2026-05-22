using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace ValueConverters
{
    public abstract class EnumWrapperConverterBase<TConverter> : SingletonConverterBase<TConverter> where TConverter : new()
    {
        public abstract EnumWrapperConverterNameStyle NameStyle { get; set; }

        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var type = value.GetType();
            var typeInfo = type.GetTypeInfo();
            if (type == targetType ||
                (typeInfo.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumWrapper<>)))
            {
                // If value from source (typically a property in a viewmodel)
                // is already EnumWrapper<T>, no further conversion needs to be done.
                return value;
            }

            if (value is IEnumerable)
            {
                if (typeInfo.IsGenericType)
                {
                    var genericType = type.GetGenericArguments()[0];
                    EnsureEnumType(genericType);

                    var enumWrapperArray = typeof(EnumWrapperConverterBase<TConverter>)?
                        .GetMethod(nameof(this.CreateEnumWrapperArray))?
                        .MakeGenericMethod(new[] { genericType })
                        .Invoke(this, new[] { value, this.NameStyle });

                    return enumWrapperArray;
                }

                if (typeInfo.IsArray)
                {
                    var elementType = type.GetElementType()!;
                    EnsureEnumType(elementType);

                    var enumWrapperArray = typeof(EnumWrapperConverterBase<TConverter>)
                        .GetMethod(nameof(this.CreateEnumWrapperArray))?
                        .MakeGenericMethod(elementType)
                        .Invoke(this, new[] { value, this.NameStyle });

                    return enumWrapperArray;
                }

                throw new NotSupportedException(
                    "EnumWrapperConverter can currently only convert IEnumerable<T> and arrays into EnumWrapper<T> objects.");
            }

            object? enumWrapper = null;
            try
            {
                EnsureEnumType(type);

                enumWrapper = typeof(EnumWrapperConverterBase<TConverter>)?
                    .GetMethod(nameof(this.CreateMapper))?
                    .MakeGenericMethod(type)
                    .Invoke(this, new[] { value, this.NameStyle });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException!).Throw();
            }

            return enumWrapper;
        }

        protected override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType), "Argument 'targetType' must not be null");
            }

            if (ReferenceEquals(value, UnsetValue) ||
                ReferenceEquals(value, Binding.DoNothing))
            {
                return Binding.DoNothing;
            }

            if (value == null)
            {
                return IsNullable(targetType) ? null : Binding.DoNothing;
            }

            var type = value.GetType();
            if (type == targetType)
            {
                Debug.WriteLine("EnumWrapperConverter was used to convert between equal types. Consider removing it in this particular situation.");
                return value;
            }

            if (IsNullable(targetType))
            {
                targetType = Nullable.GetUnderlyingType(targetType)!;
            }

            if (type == targetType)
            {
                Debug.WriteLine("EnumWrapperConverter was used to convert between equal types. Consider removing it in this particular situation.");
                return value;
            }

            EnsureEnumType(targetType);

            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumWrapper<>) && type.GetGenericArguments()[0] == targetType)
            {
                // Unpack EnumWrapper<T> if targetType equals T
                object? enumValue = null;
                try
                {
                    enumValue = typeof(EnumWrapperConverterBase<TConverter>)?
                        .GetMethod(nameof(this.UnpackEnumWrapper))?
                        .MakeGenericMethod(targetType)
                        .Invoke(this, new[] { value });
                }
                catch (TargetInvocationException ex)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException!).Throw();
                }

                return enumValue;
            }

            // TODO GATH: Check if this exception is required
            ////if (value is IEnumerable)
            ////{
            ////    throw new NotSupportedException("EnumWrapperConverter cannot convert back value of type IEnumerable<T>.");
            ////}

            // If value from source (typically a property in a viewmodel)
            // is already EnumWrapper<T>, no further conversion needs to be done.

            object? enumWrapper = null;
            try
            {
                enumWrapper = typeof(EnumWrapperConverterBase<TConverter>)?
                    .GetMethod(nameof(this.ConvertMapper))?
                    .MakeGenericMethod(new[] { targetType })
                    .Invoke(this, new[] { value });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException!).Throw();
            }

            return enumWrapper;
        }

        public TEnum ConvertMapper<TEnum>(object value)
             where TEnum : struct, Enum
        {
            return (EnumWrapper<TEnum>)value;
        }

        public EnumWrapper<TEnum> CreateMapper<TEnum>(object value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
             where TEnum : struct, Enum
        {
            return EnumWrapper.CreateWrapper((TEnum)value, nameStyle);
        }

        public TEnum UnpackEnumWrapper<TEnum>(EnumWrapper<TEnum> value)
            where TEnum : struct, Enum
        {
            return value.Value;
        }

        public IEnumerable<EnumWrapper<TEnum>> CreateEnumWrapperEnumerable<TEnum>(object values, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
             where TEnum : struct, Enum
        {
            foreach (var value in (IEnumerable)values)
            {
                yield return EnumWrapper.CreateWrapper((TEnum)value, nameStyle);
            }
        }

        public EnumWrapper<TEnum>[] CreateEnumWrapperArray<TEnum>(object values, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
             where TEnum : struct, Enum
        {
            var enumerable = this.CreateEnumWrapperEnumerable<TEnum>(values, nameStyle);
            return enumerable.ToArray();
        }

        private static bool IsNullable(Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static void EnsureEnumType(Type type)
        {
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new NotSupportedException("EnumWrapperConverter can only convert enum values and collections of enum values.");
            }
        }
    }
}
