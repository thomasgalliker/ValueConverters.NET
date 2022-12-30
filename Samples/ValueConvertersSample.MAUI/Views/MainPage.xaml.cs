using ValueConvertersSample.MAUI.ViewModels;

namespace ValueConvertersSample.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}