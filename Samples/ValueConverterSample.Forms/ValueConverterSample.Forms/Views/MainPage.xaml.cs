using System.Linq;

using ValueConverterSample.Forms.ViewModels;

using Xamarin.Forms;

namespace ValueConverterSample.Forms.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            var vm = new MainViewModel();
            this.BindingContext = vm;
        }
    }
}