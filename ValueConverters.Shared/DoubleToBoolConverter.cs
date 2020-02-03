namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(double), typeof(bool))]
#endif
    public class DoubleToBoolConverter : ValueToBoolConverter<double>
    {
    }
}
