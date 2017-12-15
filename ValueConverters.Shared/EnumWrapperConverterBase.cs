using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

#if NETFX || WINDOWS_PHONE
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

            var enumWrapper = typeof(EnumWrapperConverterBase<TConverter>).GetMethod(nameof(this.CreateMapper))
                    .MakeGenericMethod(new[] { value.GetType() })
                    .Invoke(this, new[] { value, this.NameStyle });

            return enumWrapper;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return SingletonConverterBase<TConverter>.UnsetValue;
            }

            var type = value.GetType();
            if (type == targetType)
            {
                Debug.WriteLine("EnumWrapperConverter was used to convert between equal types. Consider removing it in this particular situation.");
                return value;
            }

            // If value from source (typically a property in a viewmodel)
            // is already EnumWrapper<T>, no further conversion needs to be done.
            var enumWrapper = typeof(EnumWrapperConverterBase<TConverter>).GetMethod(nameof(this.ConvertMapper))
                 .MakeGenericMethod(new[] { targetType })
                 .Invoke(this, new[] { value });

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

        public IEnumerable<EnumWrapper<T>> CreateMapperList<T>(object values, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            foreach (var value in (IEnumerable)values)
            {
                yield return EnumWrapper.CreateWrapper((T)value, nameStyle);
            }
        }
    }
}