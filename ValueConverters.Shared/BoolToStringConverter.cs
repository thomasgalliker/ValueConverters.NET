namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(string))]
#endif
    public class BoolToStringConverter : BoolToValueConverter<string>
    {
    }
}
