#if NETFX || NETWPF
namespace ValueConverters
{
    public class VisibilityInverter : BoolToValueConverter<Visibility>
    {
        public VisibilityInverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
            this.IsInverted = true;
        }
    }
}
#endif