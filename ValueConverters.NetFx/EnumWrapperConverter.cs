using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace ValueConverters
{
    public class EnumWrapperConverter : ConverterBase
    {
        public static readonly DependencyProperty NameStyleProperty = DependencyProperty.Register(
            "NameStyle",
            typeof(EnumWrapperConverterNameStyle),
            typeof(EnumWrapperConverter),
            new PropertyMetadata(EnumWrapperConverterNameStyle.LongName));

        public EnumWrapperConverterNameStyle NameStyle
        {
            get { return (EnumWrapperConverterNameStyle)this.GetValue(NameStyleProperty); }
            set { this.SetValue(NameStyleProperty, value); }
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ConverterBase.UnsetValue;
            }

            var type = value.GetType();
            if (type == targetType || 
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumWrapper<>)))
            {
                // If value from source (typically a property in a viewmodel)
                // is already EnumWrapper<T>, no further conversion needs to be done.
                return value;
            }

            if (value is IEnumerable)
            {
                if (type.IsGenericType)
                {
                    var genericType = type.GetGenericArguments()[0];
                    var enumWrapperList = typeof(EnumWrapperConverter).GetMethod("CreateMapperList")
                        .MakeGenericMethod(new[] { genericType })
                        .Invoke(this, new[] { value, this.NameStyle });
                    return enumWrapperList;
                }

                throw new ArgumentException("EnumWrapperConverter cannot convert non-generic IEnumerable. Please bind an IEnumerable<T>.");
            }

            var enumWrapper = typeof(EnumWrapperConverter).GetMethod("CreateMapper")
                    .MakeGenericMethod(new[] { value.GetType() })
                    .Invoke(this, new[] { value, this.NameStyle });

            return enumWrapper;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ConverterBase.UnsetValue;
            }

            var type = value.GetType();
            if (type == targetType)
            {
                Debug.WriteLine("EnumWrapperConverter was used to convert between equal types. Consider removing it in this particular situation.");
                return value;
            }

            // If value from source (typically a property in a viewmodel)
            // is already EnumWrapper<T>, no further conversion needs to be done.
            var enumWrapper = typeof(EnumWrapperConverter).GetMethod("ConvertMapper")
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