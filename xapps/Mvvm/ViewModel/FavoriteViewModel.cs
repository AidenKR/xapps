using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace xapps
{
    public class FavoriteViewModel : BaseViewModel
    {
        public const string MOVIE_URL_PREFIX = "https://image.tmdb.org/t/p/w500/";
        public bool isEditingMode { get; set; }
        public ObservableCollection<FavoriteItem> favorite { get; set; }

        //public ObservableCollection<FavoriteItem> favorite { 
        //    get => favorite;
        //    set => favorite = value; 
        //}

        public FavoriteViewModel()
        {
            isEditingMode = false;
            favorite = new ObservableCollection<FavoriteItem>();

            List<FavoriteItem> dbItems = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItems();
            if (dbItems != null && dbItems.Count > 0)
            {
                favorite = new ObservableCollection<FavoriteItem>(dbItems);
            }
        }
    }
}
