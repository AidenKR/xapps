using System.Diagnostics;
using Xamarin.Forms;
using static xapps.FavoriteViewModel;

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

            showEmptyUI(favoriteViewModel.favorite.Count <= 0);
            
        }

        void onClickEditButton(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked edit button");
            if (favoriteViewModel.favorite.Count > 0)
            {
                toggleEditingUI();
            }
        }

        void onClickCancleFavorite(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked CancleFavorite button");
            favoriteViewModel.removeFavorite();
            toggleEditingUI();

            showEmptyUI(favoriteViewModel.favorite.Count <= 0);
        }

        // show list item
        void OnAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            Debug.WriteLine("appearing item");
        }

        void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("clicked item");

            if (!favoriteViewModel.isEditingMode) {
                return;
            }

            FavoriteListItem item = e.SelectedItem as FavoriteViewModel.FavoriteListItem;
            if(item != null) {
				item.isSelectedItem = !item.isSelectedItem;

                if(item.isSelectedItem) {
                    item.imageName = "co_btn_check_normal";
                } else {
                    item.imageName = "co_btn_check_unsel";
                }

                favoriteListView.ItemsSource = null;
                favoriteListView.ItemsSource = favoriteViewModel.favorite;
            }
        }

        void toggleEditingUI() {
            if (favoriteViewModel.toggleEditButton())
            {
                editBtn.Text = "취소";
                deleteBtn.IsVisible = true;
            }
            else
            {
                editBtn.Text = "편집";
                deleteBtn.IsVisible = false;
            }

            favoriteListView.ItemsSource = null;
            favoriteListView.ItemsSource = favoriteViewModel.refreshList();
        }

        void showEmptyUI(bool isEmpty) {
            if(isEmpty) {
                emptyView.IsVisible = true;
                favoriteListView.IsVisible = false;
                editBtn.IsVisible = false;
            } else {
                emptyView.IsVisible = false;
                favoriteListView.IsVisible = true;
                editBtn.IsVisible = true;
            }
        }
    }
}
