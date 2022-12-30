using Xamarin.Forms;
using XFSample.ViewModels;

namespace XFSample.Views
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