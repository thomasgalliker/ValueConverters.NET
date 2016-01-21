using ValueConverterSample.Forms.Views;

using Xamarin.Forms;

namespace ValueConverterSample.Forms
{
    public class App : Application
    {
        public App()
        {
            this.MainPage = new DemoView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}