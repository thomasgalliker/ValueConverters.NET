namespace ValueConverters
{
    public abstract class ConverterBase :
#if MAUI
        BindableObject,
#else
        DependencyObject,
#endif
        IValueConverter
    {
        /// <summary>
        /// Allows to override the default culture used in <seealso cref="IValueConverter"/> for the current converter.
        /// The default override behavior can be configured in <seealso cref="ValueConvertersConfig.DefaultPreferredCulture"/>.
        /// </summary>
        public PreferredCulture PreferredCulture { get; set; } = ValueConvertersConfig.DefaultPreferredCulture;

        /// <summary>
        /// Converts <paramref name="value"/> from binding source to binding target.
        /// </summary>
        /// <param name="value">The value provided by the binding source.</param>
        /// <param name="targetType">The type of the binding target.</param>
        /// <param name="parameter">Additional parameter (optional).</param>
        /// <param name="culture">The preferred culture (see also <seealso cref="ConverterBase.PreferredCulture"/>)</param>
        /// <returns>The converted value.</returns>
        protected abstract object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);

        /// <summary>
        /// Converts back <paramref name="value"/> from binding target to binding source.
        /// </summary>
        /// <param name="value">The value provided by the binding target.</param>
        /// <param name="targetType">The type of the binding source.</param>
        /// <param name="parameter">Additional parameter (optional).</param>
        /// <param name="culture">The preferred culture (see also <seealso cref="ConverterBase.PreferredCulture"/>)</param>
        /// <returns>The converted value.</returns>
        protected virtual object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"Converter '{this.GetType().Name}' does not support backward conversion.");
        }

        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, this.SelectCulture(() => culture));
        }

        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return this.ConvertBack(value, targetType, parameter, this.SelectCulture(() => culture));
        }
        private CultureInfo SelectCulture(Func<CultureInfo> converterCulture)
        {
            switch (this.PreferredCulture)
            {
                case PreferredCulture.CurrentCulture:
                    return CultureInfo.CurrentCulture;
                case PreferredCulture.CurrentUICulture:
                    return CultureInfo.CurrentUICulture;
                default:
                    return converterCulture();
            }
        }

#if MAUI
        public static readonly object? UnsetValue = null;
#else
        public static readonly object? UnsetValue = DependencyProperty.UnsetValue;
#endif

    }
}
