namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(object))]
#endif
    public class BoolToObjectConverter : BoolToValueConverter<object>
    {
    }
}
