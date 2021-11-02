using System.Windows;
using ValueConverters;

namespace ValueConverterSample.WPF
{
    public partial class App : Application
    {
        public App()
        {
            ValueConvertersConfig.DefaultPreferredCulture = PreferredCulture.CurrentUICulture;
        }
    }
}
