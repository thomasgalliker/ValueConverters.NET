namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(int), typeof(bool))]
#endif
    public class IntegerToBoolConverter : ValueToBoolConverter<int>
    {
    }
}
