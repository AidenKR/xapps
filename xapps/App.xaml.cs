using Xamarin.Forms;

namespace xapps
{
    public partial class App : Application
    {
        public static NetworkManager netManager { get; private set; }
        public App()
        {
            InitializeComponent();

			netManager = new NetworkManager(new RestService());

            MainPage = new xappsPage();
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
