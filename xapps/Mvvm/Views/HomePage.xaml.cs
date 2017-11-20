using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class HomePage : ContentPage, CustomTabInterface
    {
        HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomePageViewModel();

            initView();
        }

        void initView()
        {
            // TAB
            setTabBar();
        }

        void setTabBar()
        {
            List<string> tabs = new List<string> { "현재 상영작", "개봉 예정작" };
            CustomTabCellLayoutData layoutData = new CustomTabCellLayoutData()
            {
                isBoldText = true
            };

            mdpTab.makeTabLayout(tabs, layoutData);
            mdpTab.Listener = this;
        }

        bool hasAppearedOnce = false;
        protected override void OnAppearing()
        {
            Debug.WriteLine(">> OnAppearing()");

            base.OnAppearing();

            if (!hasAppearedOnce)
            {
                hasAppearedOnce = true;

                HListView.HeightRequest = HListViewLayout.Width;

                Debug.WriteLine("HListView.Width : " + HListView.Width);
            }

            if (viewModel.Items == null || viewModel.Items.Count == 0) {
                viewModel.LoadItemsCommand.Execute(HomePageViewModel.TYPE_NOW_PLAYING);
            }
        }

        public void onClickTabButton(object index)
        {
            Debug.WriteLine("Tab Selected Index : " + index);

            int type = ListPageViewModel.TYPE_NOW_PLAYING;
            if (Convert.ToInt32(index) != 0)
            {
                type = ListPageViewModel.TYPE_UPCOMING;
            }
            viewModel.LoadItemsCommand.Execute(type);
        }

        async void HListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as results;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetailPage(item.id));

            // Manually deselect item
            HListView.SelectedItem = null;
        }

        async void ViewAllClick(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ListPage(viewModel.SelectedCategoryType));
        }
    }
}
