namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(double))]
#endif
    public class BoolToDoubleConverter : BoolToValueConverter<double>
    {
    }
}
