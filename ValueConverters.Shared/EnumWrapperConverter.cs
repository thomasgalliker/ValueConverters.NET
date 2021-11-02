#if XAMARIN
using Xamarin.Forms;
#endif

#if NETFX || NET5_0_OR_GREATER
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class EnumWrapperConverter : EnumWrapperConverterBase<EnumWrapperConverter>
    {
#if XAMARIN
        public static readonly BindableProperty NameStyleProperty = BindableProperty.Create(
            "NameStyle",
            typeof(EnumWrapperConverterNameStyle),
            typeof(EnumWrapperConverter),
            EnumWrapperConverterNameStyle.LongName);

#else
        public static readonly DependencyProperty NameStyleProperty = DependencyProperty.Register(
            "NameStyle",
            typeof(EnumWrapperConverterNameStyle),
            typeof(EnumWrapperConverter),
            new PropertyMetadata(EnumWrapperConverterNameStyle.LongName));
#endif

        public override EnumWrapperConverterNameStyle NameStyle
        {
            get { return (EnumWrapperConverterNameStyle)this.GetValue(NameStyleProperty); }
            set { this.SetValue(NameStyleProperty, value); }
        }
    }
}
