using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static xapps.CustomTabView;
using static xapps.ListPage;

namespace xapps
{
    public partial class BooksHomePage : ContentPage, ICustomTabInterface
    {
        BooksHomePageViewModel viewModel;

        readonly List<TabData> BooksTabList = new List<TabData>
            {
                new TabData{ Title = "베스트셀러", Tag = CategoryManager.TYPE_BOOKS_BEST_SELLER },
                new TabData{ Title = "추천도서", Tag = CategoryManager.TYPE_BOOKS_RECOMMEND },
                new TabData{ Title = "신간도서", Tag = CategoryManager.TYPE_BOOKS_NEW_BOOK }
            };

        public BooksHomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BooksHomePageViewModel();

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

            BooksTab.MakeTabLayout(BooksTabList, layoutData);
            BooksTab.Listener = this;
        }

        bool hasAppearedOnce = false;
        protected override void OnAppearing()
        {
            Debug.WriteLine(">> OnAppearing()");

            base.OnAppearing();

            if (!hasAppearedOnce)
            {
                hasAppearedOnce = true;

                BooksListView.HeightRequest = App.ScreenWidth;

                Debug.WriteLine("BooksListViewLayout.HeightRequest : " + BooksListViewLayout.Width);
                Debug.WriteLine("BooksListView.HeightRequest : " + BooksListView.HeightRequest);
            }

            if (viewModel.BooksItems == null || viewModel.BooksItems.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(CategoryManager.TYPE_BOOKS_BEST_SELLER);
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

        async void BooksListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as BookItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new WebviewPage(item.mobileLink));

            // Manually deselect item
            BooksListView.SelectedItem = null;
        }

        async void BooksViewAllClick(object sender, System.EventArgs e)
        {
            List<ListPageTab> TypeList = new List<ListPageTab>();

            for (int i = 0; i < BooksTabList.Count; i++)
            {
                TypeList.Add(new ListPageTab
                {
                    Title = BooksTabList[i].Title,
                    Type = (int)BooksTabList[i].Tag,
                    IsSelected = (int)BooksTabList[i].Tag == viewModel.SelectBooksCategoryType
                });
            }

            await Navigation.PushAsync(new ListPage(TypeList));
        }
    }
}
