using Xamarin.Forms;

namespace xapps
{
    public partial class App : Application
    {
        //Create two static doubles that will be used to size elements
        public static double ScreenWidth;
        public static double ScreenHeight;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
