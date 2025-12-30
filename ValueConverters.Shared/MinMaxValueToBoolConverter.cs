namespace ValueConverters
{
    /// <summary>
    /// Checks if the value is between MinValue and MaxValue,
    /// returning true if the value is within the range and false if the value is out of the range.
    /// 
    /// All involved values (converter parameter 'value', MinValue and MaxValue) must be of the same type
    /// and must implement <seealso cref="IComparable"/> (https://docs.microsoft.com/en-us/dotnet/api/system.icomparable).
    /// </summary>
    public class MinMaxValueToBoolConverter : SingletonConverterBase<MinMaxValueToBoolConverter>
    {
#if MAUI
        public static readonly BindableProperty MaxValueProperty =
            BindableProperty.Create(
                nameof(MaxValue),
                typeof(object),
                typeof(MinMaxValueToBoolConverter));

        public static readonly BindableProperty MinValueProperty =
            BindableProperty.Create(
                nameof(MinValue),
                typeof(object),
                typeof(MinMaxValueToBoolConverter));
#else
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register(
                nameof(MaxValue),
                typeof(object),
                typeof(MinMaxValueToBoolConverter),
                new PropertyMetadata(defaultValue: null));

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register(
                nameof(MinValue),
                typeof(object),
                typeof(MinMaxValueToBoolConverter),
                new PropertyMetadata(defaultValue: null));
#endif

        public object MaxValue
        {
            get => this.GetValue(MaxValueProperty);
            set => this.SetValue(MaxValueProperty, value);
        }

        public object MinValue
        {
            get => this.GetValue(MinValueProperty);
            set => this.SetValue(MinValueProperty, value);
        }

        /// <inheritdoc/>
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not IComparable comparable)
            {
                return UnsetValue;
            }

            if (this.MinValue is not IComparable)
            {
                throw new ArgumentException("MinValue must implement IComparable interface", nameof(this.MinValue));
            }

            if (this.MaxValue is not IComparable)
            {
                throw new ArgumentException("MaxValue must implement IComparable interface", nameof(this.MaxValue));
            }

            var minValue = System.Convert.ChangeType(this.MinValue, comparable.GetType());
            var maxValue = System.Convert.ChangeType(this.MaxValue, comparable.GetType());

            return comparable.CompareTo(minValue) >= 0 && comparable.CompareTo(maxValue) <= 0;
        }
    }
}