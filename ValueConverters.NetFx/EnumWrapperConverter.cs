using System.Windows;

namespace ValueConverters
{
    public class EnumWrapperConverter : EnumWrapperConverterBase
    {
        public static readonly DependencyProperty NameStyleProperty = DependencyProperty.Register(
            "NameStyle",
            typeof(EnumWrapperConverterNameStyle),
            typeof(EnumWrapperConverter),
            new PropertyMetadata(EnumWrapperConverterNameStyle.LongName));

        public override EnumWrapperConverterNameStyle NameStyle
        {
            get { return (EnumWrapperConverterNameStyle)this.GetValue(NameStyleProperty); }
            set { this.SetValue(NameStyleProperty, value); }
        }
    }
}
