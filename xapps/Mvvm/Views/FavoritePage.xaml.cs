using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class FavoritePage : ContentPage
    {
        public FavoriteViewModel favoriteViewModel;

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
            BindingContext = favoriteViewModel = new FavoriteViewModel();
            Debug.WriteLine("favorite list count = " + favoriteViewModel.favorite.Count);

            if (favoriteViewModel.favorite.Count <= 0)
            {
                emptyView.IsVisible = true;
                favoriteListView.IsVisible = false;
                editBtn.IsVisible = false;
            }
            else
            {
                emptyView.IsVisible = false;
                favoriteListView.IsVisible = true;
                editBtn.IsVisible = true;
            }
        }

        void onClickEditButton(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked edit button");
            favoriteViewModel.isEditingMode = !favoriteViewModel.isEditingMode;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
