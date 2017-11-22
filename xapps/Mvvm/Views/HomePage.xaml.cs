using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static xapps.ListPage;

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

                HListView.HeightRequest = App.ScreenWidth;

                Debug.WriteLine("HListViewLayout.HeightRequest : " + HListViewLayout.Width);
                Debug.WriteLine("HListView.HeightRequest : " + HListView.HeightRequest);
            }

            if (viewModel.Items == null || viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(HomePageViewModel.TYPE_NOW_PLAYING);
            }
        }

        public void onClickTabButton(int index)
        {
            Debug.WriteLine("Tab Selected Index : " + index);

            int type = ListPageViewModel.TYPE_MOVIE_NOW_PLAYING;
            if (index != 0)
            {
                type = ListPageViewModel.TYPE_MOVIE_UPCOMING;
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
            // TODO 정리 필요
            List<Tab> TypeList = new List<Tab>
            {
                new Tab{ Title = "현재 상영작", Type = ListPageViewModel.TYPE_MOVIE_NOW_PLAYING, IsSelected = true },
                new Tab{ Title = "개봉 예정작", Type = ListPageViewModel.TYPE_MOVIE_UPCOMING }
            };

            await Navigation.PushAsync(new ListPage(TypeList));
        }

        async void BooksViewAllClick(object sender, System.EventArgs e)
        {
            // TODO 정리 필요
            List<Tab> TypeList = new List<Tab>
            {
                new Tab{ Title = "베스트셀러", Type = ListPageViewModel.TYPE_BOOKS_BEST_SELLER, IsSelected = true },
                new Tab{ Title = "추천도서", Type = ListPageViewModel.TYPE_BOOKS_RECOMMEND },
                new Tab{ Title = "신간도서", Type = ListPageViewModel.TYPE_BOOKS_NEW_BOOK }
            };

            await Navigation.PushAsync(new ListPage(TypeList));
        }
    }
}
