using Xamarin.Forms;

namespace xapps
{
    public partial class ListPage : ContentPage
    {
        ListPageViewModel viewModel;

        public ListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                SelectedCategory(NowPlayingBtn);
        }


        #region EventHandler
        void CategoryBtnClicked(object sender, System.EventArgs e)
        {
            SelectedCategory(sender as Button);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as results;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetailPage());

            // Manually deselect item
            listView.SelectedItem = null;
        }
        #endregion

        private void SelectedCategory(Button btn)
        {
            ChangeTextColor(btn);

            int requestType = ListPageViewModel.TYPE_NOW_PLAYING;
            if (btn != NowPlayingBtn) {
                requestType = ListPageViewModel.TYPE_UPCOMING;
            }

            viewModel.LoadItemsCommand.Execute(requestType);
        }

        // Selected Button Text Color
        private void ChangeTextColor(Button selectedBtn)
        {
            NowPlayingBtn.TextColor = Color.FromHex("000000");
            UpcomingBtn.TextColor = Color.FromHex("000000");

            selectedBtn.TextColor = Color.FromHex("FF0000");

        }
    }
}
