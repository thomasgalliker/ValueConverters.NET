using System;
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
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumWrapper<>))
            {
                // If value from source (typically a property in a viewmodel)
                // is already EnumWrapper<T>, no further conversion needs to be done.
                return value;
            }

            return
                typeof(EnumWrapperConverter).GetMethod("CreateMapper")
                    .MakeGenericMethod(new[] { value.GetType() })
                    .Invoke(this, new[] { value, this.NameStyle });
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ConverterBase.UnsetValue;
            }

            var type = value.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumWrapper<>))
            {
                // If value from source (typically a property in a viewmodel)
                // is already EnumWrapper<T>, no further conversion needs to be done.
                return
                 typeof(EnumWrapperConverter).GetMethod("ConvertMapper")
                     .MakeGenericMethod(new[] { targetType })
                     .Invoke(this, new[] { value });
            }

            return value;
        }

        public T ConvertMapper<T>(object value)
        {
            return (EnumWrapper<T>)value;
        }

        public EnumWrapper<T> CreateMapper<T>(object value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName)
        {
            return EnumWrapper.CreateWrapper((T)value, nameStyle);
        }
    }
}