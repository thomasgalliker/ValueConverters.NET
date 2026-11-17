namespace ValueConverters
{
    /// <summary>
    /// Value converters which aggregates the results of a sequence of converters: Converter1 >> Converter2 >> Converter3
    /// The output of converter N becomes the input of converter N+1.
    /// </summary>
    [ContentProperty(nameof(Converters))]
    public class ValueConverterGroup : SingletonConverterBase<ValueConverterGroup>
    {
        public List<IValueConverter>? Converters { get; set; } = new List<IValueConverter>();

        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (this.Converters is IEnumerable<IValueConverter> converters)
            {
                var language = culture;
                return converters.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, language));
            }

            return UnsetValue;
        }

        protected override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (this.Converters is IEnumerable<IValueConverter> converters)
            {
                var language = culture;
                return converters.Reverse<IValueConverter>().Aggregate(value, (current, converter) => converter.ConvertBack(current, targetType, parameter, language));
            }

            return UnsetValue;
        }
    }
}
