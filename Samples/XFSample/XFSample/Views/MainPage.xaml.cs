using XFSample.ViewModels;
using Xamarin.Forms;

namespace XFSample.Views
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