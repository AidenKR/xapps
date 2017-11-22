#define USE_TEST_DATA

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace xapps
{
    public class FavoriteViewModel : BaseViewModel
    {
        public const string MOVIE_URL_PREFIX = "https://image.tmdb.org/t/p/w500/";
        public bool isEditingMode = false;
        //ObservableCollection<FavoriteItem> favorite { get; set; }

        public ObservableCollection<FavoriteItem> favorite { 
            get => favorite;
            set => favorite = value; 
        }

        public FavoriteViewModel()
        {
            favorite = new ObservableCollection<FavoriteItem>();

            List<FavoriteItem> dbItems = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItems();

#if USE_TEST_DATA
            if(dbItems== null || dbItems.Count <= 0) {
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
                    var result = DatabaseManager.Instance.GetTable<FavoriteItem>().InsertItem(item);
                    Debug.WriteLine("save item index {0}: result = {1}", i, result);
                }
            }
#endif

            if (dbItems != null && dbItems.Count > 0)
            {
            //    emptyView.IsVisible = false;
            //    favoriteListView.IsVisible = true;
            //    editBtn.IsVisible = true;
                favorite = new ObservableCollection<FavoriteItem>(dbItems);
            //    favoriteListView.ItemsSource = favorite;
            //    Debug.WriteLine("favorite list count = " + favorite.Count);
            }
            else
            {
            //    emptyView.IsVisible = true;
            //    favoriteListView.IsVisible = false;
            //    editBtn.IsVisible = false;
            }
        }
    }
}
