using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class FavoriteViewModel : BaseViewModel
    {
        public const string MOVIE_URL_PREFIX = "https://image.tmdb.org/t/p/w500/";
        public ObservableCollection<FavoriteListItem> favorite { get; set; }
        bool isEditingMode { get; set; }

        public FavoriteViewModel()
        {
            isEditingMode = false;
            favorite = new ObservableCollection<FavoriteListItem>();

            List<FavoriteItem> dbItems = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItems();
            if (dbItems != null && dbItems.Count > 0)
            {
                List<FavoriteListItem> list = new List<FavoriteListItem>();
                foreach (FavoriteItem item in dbItems)
                {
                    list.Add(new FavoriteListItem(item, isEditingMode));
                }
                favorite = new ObservableCollection<FavoriteListItem>(list);
            }
        }

        public bool toggleEditButton() {
            isEditingMode = !isEditingMode;
            return isEditingMode;
        }

        public ObservableCollection<FavoriteListItem> refreshList() {
            favorite.Clear();

            List<FavoriteItem> dbItems = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItems();
            if (dbItems != null && dbItems.Count > 0)
            {
                List<FavoriteListItem> list = new List<FavoriteListItem>();
                foreach (FavoriteItem item in dbItems) {
                    list.Add(new FavoriteListItem(item, isEditingMode));
                }
                favorite = new ObservableCollection<FavoriteListItem>(list);
            }

            return favorite;
        }

        public void removeFavorite() {
            Debug.WriteLine("removeFavorite");

            foreach(FavoriteListItem item in favorite) {

                if(item.isSelectedItem) {
                    Debug.WriteLine("isSelectedItem Title = " + item.title);				
                    DatabaseManager.Instance.GetTable<FavoriteItem>().DeleteItem(item.movieId);
                }
            }

            var toast = DependencyService.Get<IToastAlert>();
            if (null != toast)
            {
                toast.showToast("delete favorite on select item", false);
            }
        }

        public class FavoriteListItem : FavoriteItem
        {
            public bool isEditingMode { get; set; }
            public bool isSelectedItem { get; set; }
            public string imageName { get; set; }

            public FavoriteListItem(FavoriteItem item, bool isEditable) {

                this.movieId = item.movieId;
                this.favoriteYN = item.favoriteYN;
                this.title = item.title;
                this.original_title = item.original_title;
                this.poster_path = item.poster_path;
                this.vote_average = item.vote_average;
                this.release_date = item.release_date;
                this.isEditingMode = isEditable;
                this.isSelectedItem = false;
                this.imageName = "co_btn_check_unsel";
            }
        }
    }
}
