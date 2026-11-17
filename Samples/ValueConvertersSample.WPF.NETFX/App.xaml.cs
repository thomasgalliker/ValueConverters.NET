using System.Windows;
using ValueConverters;

namespace ValueConvertersSample.WPF
{
    public partial class App : Application
    {
        public App()
        {
            ValueConvertersConfig.DefaultPreferredCulture = PreferredCulture.CurrentUICulture;
        }
    }
}
