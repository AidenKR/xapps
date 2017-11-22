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
