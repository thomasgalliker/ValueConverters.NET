namespace ValueConverters
{
#if (NETFX || NET_CORE)
    [System.Windows.Data.ValueConversion(typeof(bool), typeof(bool))]
#endif
    public class BoolNegationConverter : BoolToValueConverter<bool>
    {
        public BoolNegationConverter()
        {
            this.TrueValue = true;
            this.FalseValue = false;
            this.IsInverted = true;
        }
    }

    public class InverseBoolConverter : BoolNegationConverter
    {
    }

    public class BoolInverter : BoolNegationConverter
    {
    }
}
