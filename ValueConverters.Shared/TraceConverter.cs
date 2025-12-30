using System.Diagnostics;

namespace ValueConverters
{
    /// <summary>
    /// Writes Trace.WriteLine with value, targetType, parameter and culture.
    /// </summary>
    public class TraceConverter : SingletonConverterBase<TraceConverter>
    {
        protected override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Trace.WriteLine($"TraceConverter.Convert(" +
                            $"value={value ?? "null"}, " +
                            $"targetType={(object)targetType ?? "null"}, " +
                            $"parameter={parameter ?? "null"}, " +
                            $"culture={(object)culture ?? "null"})");

            return value;
        }

        protected override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Trace.WriteLine($"TraceConverter.ConvertBack(" +
                            $"value={value ?? "null"}, " +
                            $"targetType={(object)targetType ?? "null"}, " +
                            $"parameter={parameter ?? "null"}, " +
                            $"culture={(object)culture ?? "null"})");

            return value;
        }
    }
}