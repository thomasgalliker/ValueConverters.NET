using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.ExceptionServices;
#if NETFX || NET5_0_OR_GREATER
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif
#if XAMARIN || (NETFX_CORE && !WINDOWS_UWP)
using ValueConverters.Extensions;
#endif

namespace ValueConverters
{
    public abstract class EnumWrapperConverterBase<TConverter> : SingletonConverterBase<TConverter> where TConverter : new()
    {
        public abstract EnumWrapperConverterNameStyle NameStyle { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return UnsetValue;
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
                    var enumWrapperList = typeof(EnumWrapperConverterBase<TConverter>).GetMethod(nameof(this.CreateMapperList))
                        .MakeGenericMethod(new[] { genericType })
                        .Invoke(this, new[] { value, this.NameStyle });
                    return enumWrapperList;
                }

                throw new ArgumentException("EnumWrapperConverter cannot convert non-generic IEnumerable. Please bind an IEnumerable<T>.");
            }

            object enumWrapper = null;
            try
            {
                enumWrapper = typeof(EnumWrapperConverterBase<TConverter>).GetMethod(nameof(this.CreateMapper))
                    .MakeGenericMethod(new[] { type })
                    .Invoke(this, new[] { value, this.NameStyle });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }

            return enumWrapper;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return UnsetValue;
            }

            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType), "Argument 'targetType' must not be null");
            }

            if (IsNullable(targetType))
            {
                targetType = Nullable.GetUnderlyingType(targetType);
            }

            var type = value.GetType();
            if (type == targetType)
            {
                Debug.WriteLine("EnumWrapperConverter was used to convert between equal types. Consider removing it in this particular situation.");
                return value;
            }

            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumWrapper<>) && type.GetGenericArguments()[0] == targetType)
            {
                // Unpack EnumWrapper<T> if targetType equals T
                object enumValue = null;
                try
                {
                    enumValue = typeof(EnumWrapperConverterBase<TConverter>).GetMethod(nameof(this.UnpackEnumWrapper))
                        .MakeGenericMethod(new[] { targetType })
                        .Invoke(this, new[] { value });
                }
                catch (TargetInvocationException ex)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
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

            object enumWrapper = null;
            try
            {
                enumWrapper = typeof(EnumWrapperConverterBase<TConverter>).GetMethod(nameof(this.ConvertMapper))
                    .MakeGenericMethod(new[] { targetType })
                    .Invoke(this, new[] { value });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }

            return enumWrapper;
        }

        public T ConvertMapper<T>(object value)
        {
            return (EnumWrapper<T>)value;
        }

        public EnumWrapper<T> CreateMapper<T>(object value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            return EnumWrapper.CreateWrapper((T)value, nameStyle);
        }

        public T UnpackEnumWrapper<T>(EnumWrapper<T> value)
        {
            return value.Value;
        }

        public IEnumerable<EnumWrapper<T>> CreateMapperList<T>(object values, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            foreach (var value in (IEnumerable)values)
            {
                yield return EnumWrapper.CreateWrapper((T)value, nameStyle);
            }
        }

        private static bool IsNullable(Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}