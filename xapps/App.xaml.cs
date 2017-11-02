using Xamarin.Forms;
using xapps.DatabaseHelper;
using xapps.DatabaseHelper.Interface;

namespace xapps
{
    public partial class App : Application
    {
        static MovieFavoritesDB mMFdatabase;

        public App()
        {
            InitializeComponent();

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

        /**
         * MovieFavoritesDB Instance.
         */
        public static MovieFavoritesDB MFDatabase
        {
            get
            {
                if (null == mMFdatabase)
                {
                    mMFdatabase = new MovieFavoritesDB(DependencyService.Get<IDBFilePath>().GetLocalFilePath("MFSQLite.db3"));
                }
                return mMFdatabase;
            }
        }
    }
}
