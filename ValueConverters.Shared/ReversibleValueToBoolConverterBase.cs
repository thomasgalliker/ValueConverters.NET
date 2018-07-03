using System;
using System.Globalization;

namespace ValueConverters
{
    public abstract class ReversibleValueToBoolConverterBase<T, TConverter> 
        : ValueToBoolConverterBase<T, TConverter>
        where TConverter : new()
    {
        public abstract T FalseValue { get; set; }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true.Equals(value) ^ this.IsInverted ? this.TrueValue : this.FalseValue;
        }
    }
}