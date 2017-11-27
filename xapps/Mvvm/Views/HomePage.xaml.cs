using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static xapps.CustomTabView;
using static xapps.ListPage;

namespace xapps
{
    public partial class HomePage : ContentPage, ICustomTabInterface
    {
        HomePageViewModel viewModel;

        readonly List<TabData> MovieTabList = new List<TabData>
            {
                new TabData{ Title = "현재 상영작", Tag = CategoryManager.TYPE_MOVIE_NOW_PLAYING },
                new TabData{ Title = "개봉 예정작", Tag = CategoryManager.TYPE_MOVIE_UPCOMING }
            };

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
            CustomTabCellLayoutData layoutData = new CustomTabCellLayoutData()
            {
                isBoldText = true
            };

            MovieTab.MakeTabLayout(MovieTabList, layoutData);
            MovieTab.Listener = this;
        }

        bool hasAppearedOnce = false;
        protected override void OnAppearing()
        {
            Debug.WriteLine(">> OnAppearing()");

            base.OnAppearing();

            if (!hasAppearedOnce)
            {
                hasAppearedOnce = true;

                MovieListView.HeightRequest = App.ScreenWidth;

                Debug.WriteLine("MovieListViewLayout.HeightRequest : " + MovieListViewLayout.Width);
                Debug.WriteLine("MovieListView.HeightRequest : " + MovieListView.HeightRequest);
            }

            if (viewModel.MovieItems == null || viewModel.MovieItems.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(CategoryManager.TYPE_MOVIE_NOW_PLAYING);
            }
        }

        public void OnClickTabButton(int index, Object tag)
        {
            Debug.WriteLine("Tab Selected Index : " + index);

            if (tag == null)
            {
                return;
            }
            viewModel.LoadItemsCommand.Execute(Int32.Parse(tag.ToString()));
        }

        async void MovieListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as results;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetailPage(item.id));

            // Manually deselect item
            MovieListView.SelectedItem = null;
        }

        async void MovieViewAllClick(object sender, System.EventArgs e)
        {
            List<ListPageTab> TypeList = new List<ListPageTab>();

            for (int i = 0; i < MovieTabList.Count; i++)
            {
                TypeList.Add(new ListPageTab
                {
                    Title = MovieTabList[i].Title,
                    Type = (int)MovieTabList[i].Tag,
                    IsSelected = (int)MovieTabList[i].Tag == viewModel.SelectMovieCategoryType
                });
            }

            await Navigation.PushAsync(new ListPage(TypeList));
        }
    }
}
