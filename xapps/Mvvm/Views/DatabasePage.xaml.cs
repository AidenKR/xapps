using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class DatabasePage : ContentPage
    {
        static MovieFavoritesDB mMFdatabase;

        public DatabasePage()
        {
            InitializeComponent();
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
                    mMFdatabase = new MovieFavoritesDB(DependencyService.Get<IDBFilePath>().GetLocalFilePath(DatabaseConsts.DataBaseFileFullName));
                }
                return mMFdatabase;
            }
        }
    }
}
