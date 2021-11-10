using System;
using System.Globalization;

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
    /// <summary>
    /// Checks if the value is between MinValue and MaxValue,
    /// returning true if the value is within the range and false if the value is out of the range.
    /// 
    /// All involved values (converter parameter 'value', MinValue and MaxValue) must be of the same type
    /// and must implement <seealso cref="IComparable"/> (https://docs.microsoft.com/en-us/dotnet/api/system.icomparable).
    /// </summary>
    public class MinMaxValueToBoolConverter : SingletonConverterBase<MinMaxValueToBoolConverter>
    {
#if XAMARIN
        public static readonly BindableProperty MaxValueProperty = 
            BindableProperty.Create(
                nameof(MaxValue),
                typeof(IComparable),
                typeof(MinMaxValueToBoolConverter));

        public static readonly BindableProperty MinValueProperty = 
            BindableProperty.Create(
                nameof(MinValue),
                typeof(IComparable),
                typeof(MinMaxValueToBoolConverter));
#else
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register(
                nameof(MaxValue),
                typeof(IComparable),
                typeof(MinMaxValueToBoolConverter),
                new PropertyMetadata(defaultValue: null));

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register(
                nameof(MinValue),
                typeof(IComparable),
                typeof(MinMaxValueToBoolConverter),
                new PropertyMetadata(defaultValue: null));
#endif

        public IComparable MaxValue
        {
            get => (IComparable)this.GetValue(MaxValueProperty);
            set => this.SetValue(MaxValueProperty, value);
        }

        public IComparable MinValue
        {
            get => (IComparable)this.GetValue(MinValueProperty);
            set => this.SetValue(MinValueProperty, value);
        }

        /// <inheritdoc/>
        protected override object Convert(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not IComparable comparable)
            {
                return UnsetValue;
            }

            var minValue = System.Convert.ChangeType(this.MinValue, comparable.GetType());
            var maxValue = System.Convert.ChangeType(this.MaxValue, comparable.GetType());

            var inRange = comparable.CompareTo(minValue) >= 0 && comparable.CompareTo(maxValue) <= 0;
            return inRange;
        }
    }
}