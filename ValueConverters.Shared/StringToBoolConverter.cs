namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(string), typeof(bool))]
#endif
    public class StringToBoolConverter : ValueToBoolConverter<string>
    {
    }
}
