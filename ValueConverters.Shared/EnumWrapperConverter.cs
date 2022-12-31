#if (NETFX || NETWPF)
using System.Windows;

#elif (NETFX_CORE)
using Windows.UI.Xaml;

#elif XAMARIN
using Xamarin.Forms;
#endif

namespace ValueConverters
{
    public class EnumWrapperConverter : EnumWrapperConverterBase<EnumWrapperConverter>
    {
#if XAMARIN || MAUI
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
            get => (EnumWrapperConverterNameStyle)this.GetValue(NameStyleProperty);
            set => this.SetValue(NameStyleProperty, value);
        }
    }
}
