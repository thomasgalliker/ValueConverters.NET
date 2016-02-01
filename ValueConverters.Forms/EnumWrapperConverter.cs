using System.Windows;

using Xamarin.Forms;

namespace ValueConverters
{
    public class EnumWrapperConverter : EnumWrapperConverterBase
    {
        public static readonly BindableProperty NameStyleProperty = BindableProperty.Create(
            "Format",
            typeof(EnumWrapperConverterNameStyle),
            typeof(EnumWrapperConverter),
            EnumWrapperConverterNameStyle.LongName);

        public override EnumWrapperConverterNameStyle NameStyle
        {
            get { return (EnumWrapperConverterNameStyle)this.GetValue(NameStyleProperty); }
            set { this.SetValue(NameStyleProperty, value); }
        }
    }
}
