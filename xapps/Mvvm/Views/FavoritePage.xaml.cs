using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using xapps.Mvvm.Model.Database.FavoriteItem;
using xapps.Mvvm.Services.Database;
using xapps.Mvvm.Services.Database.FavoriteDB;

namespace xapps
{
    public partial class FavoritePage : ContentPage
    {
        readonly Database database;
        public const string MOVIE_URL_PREFIX = "https://image.tmdb.org/t/p/w500/";

        //FavoriteDB favoriteDB;
        public ObservableCollection<FavoriteItem> favorite { get; set; }

        public FavoritePage()
        {
            InitializeComponent();

            //favoriteListView.ItemAppearing += (sender, e) =>
            //{
            //    Debug.WriteLine("ItemAppearing....");
            //};

            database = new Database("FavoriteListDB");
            database.CreateTable<FavoriteItem>();

            initData();
        }

        public void initData() {
            List<FavoriteItem> dbItems = database.getAllDBItem();
            favorite = new ObservableCollection<FavoriteItem>(dbItems);
            favoriteListView.ItemsSource = favorite;
			Debug.WriteLine("favorite list count = " + favorite.Count);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked delete button");
   //         FavoriteItem data = dbList[index];
   //         IEnumerator<FavoriteItem> enumdata = database.getFilteredMovieId(data.movieId).GetEnumerator();
   //         if (enumdata.MoveNext() == false) {
   //             database.SaveItem(data);
   //             Debug.WriteLine("adding data[ " + index + " ] : title = " + data.title);
   //         } else {
   //             Debug.WriteLine("has item");
   //         }
			//index += 1;
        }

        // show list item
        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            Debug.WriteLine("appearing item");
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("clicked item");
        }
    }
}
