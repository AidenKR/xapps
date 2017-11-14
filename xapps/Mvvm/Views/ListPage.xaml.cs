using Xamarin.Forms;

namespace xapps
{
    public partial class ListPage : ContentPage
    {
        ListPageViewModel viewModel;
        private int nSelectedButtonType = ListPageViewModel.TYPE_NOW_PLAYING;
        private int nPageNumber = 0;
        private bool dataLoading;

        public ListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                SelectedCategory(NowPlayingBtn);
            }

            nPageNumber++;
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

            await Navigation.PushAsync(new DetailPage(item.id));

            // Manually deselect item
            listView.SelectedItem = null;
        }

        void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = e.Item as results;
            int index = viewModel.Items.IndexOf(item);
            if (viewModel.Items.Count - 1 <= index)
            {
                // NextDataReqeust
                NextDataReqeust();
            }
        }
        #endregion

        private void SelectedCategory(Button btn)
        {
            ChangeTextColor(btn);

            int requestType = ListPageViewModel.TYPE_NOW_PLAYING;
            if (btn != NowPlayingBtn)
            {
                requestType = ListPageViewModel.TYPE_UPCOMING;
            }
            nSelectedButtonType = requestType;

            viewModel.LoadItemsCommand.Execute(requestType);
        }

        // Selected Button Text Color
        private void ChangeTextColor(Button selectedBtn)
        {
            NowPlayingBtn.TextColor = Color.FromHex("000000");
            UpcomingBtn.TextColor = Color.FromHex("000000");

            selectedBtn.TextColor = Color.FromHex("FF0000");

        }

        void NextDataReqeust()
        {
            if (dataLoading)
            {
                return;
            }

            dataLoading = true;
            nPageNumber++;
            int[] reqValues = { nSelectedButtonType, nPageNumber };

            viewModel.MoreItemsCommand.Execute(reqValues);

            dataLoading = false;
        }
    }
}
