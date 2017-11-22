#define USE_TEST_DATA

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace xapps
{
    public partial class FavoritePage : ContentPage
    {
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

            initData();
        }

        public void initData()
        {
            List<FavoriteItem> dbItems = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItems();

#if USE_TEST_DATA
            if (dbItems == null || dbItems.Count <= 0)
            {
                DatabaseManager.Instance.GetTable<FavoriteItem>().CreateTable();
                for (int i = 0; i < 20; i++)
                {
                    var item = new FavoriteItem
                    {
                        movieId = "id" + i,
                        favoriteYN = true,
                        original_title = "original_title " + i,
                        title = "title" + i
                    };

                    dbItems.Add(item);
                    var result = DatabaseManager.Instance.GetTable<FavoriteItem>().InsertItem(item);
                    Debug.WriteLine("save item index {0}: result = {1}", i, result);
                }
			}
#endif

            if (dbItems != null && dbItems.Count > 0)
            {
                emptyView.IsVisible = false;
                favoriteListView.IsVisible = true;
                editBtn.IsVisible = true;
                favorite = new ObservableCollection<FavoriteItem>(dbItems);
                favoriteListView.ItemsSource = favorite;
                Debug.WriteLine("favorite list count = " + favorite.Count);
            } else {
                emptyView.IsVisible = true;
                favoriteListView.IsVisible = false;
                editBtn.IsVisible = false;
            }
        }

        void onClickEditButton(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked edit button");
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
        void OnAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            Debug.WriteLine("appearing item");
        }

        void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("clicked item");
        }
    }
}
