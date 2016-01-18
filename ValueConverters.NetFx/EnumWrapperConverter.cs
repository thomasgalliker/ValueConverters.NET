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
                return DependencyProperty.UnsetValue;
            }

            return
                typeof (EnumWrapperConverter).GetMethod("CreateMapper")
                    .MakeGenericMethod(new[] {value.GetType()})
                    .Invoke(this, new[] {value, this.NameStyle});
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return
                typeof (EnumWrapperConverter).GetMethod("ConvertMapper")
                    .MakeGenericMethod(new[] {targetType})
                    .Invoke(this, new[] {value});
        }

        public T ConvertMapper<T>(object value) where T : IConvertible
        {
            return (EnumWrapper<T>) value;
        }

        public EnumWrapper<T> CreateMapper<T>(object value, EnumWrapperConverterNameStyle nameStyle = EnumWrapperConverterNameStyle.LongName) where T : IConvertible
        {
            return EnumWrapper.CreateWrapper((T)value, nameStyle);
        }
    }
}