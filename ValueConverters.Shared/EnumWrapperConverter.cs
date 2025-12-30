namespace ValueConverters
{
    public class EnumWrapperConverter : EnumWrapperConverterBase<EnumWrapperConverter>
    {
#if MAUI
        public static readonly BindableProperty NameStyleProperty = BindableProperty.Create(
            nameof(NameStyle),
            typeof(EnumWrapperConverterNameStyle),
            typeof(EnumWrapperConverter),
            EnumWrapperConverterNameStyle.LongName);

#else
        public static readonly DependencyProperty NameStyleProperty = DependencyProperty.Register(
            nameof(NameStyle),
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
