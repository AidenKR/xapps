using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class ListPage : ContentPage, CustomTabInterface
    {
        public class Tab
        {
            public string Title { get; set; }
            public int Type { get; set; }
            public bool IsSelected { get; set; } = false;
        }

        ListPageViewModel viewModel;

        List<Tab> TypeList;
        Tab selectedTab;
        int pageNumber;

        bool dataLoading;

        public ListPage(List<Tab> tabs)
        {
            InitializeComponent();

            TypeList = tabs ?? throw new ArgumentNullException();

            selectedTab = tabs.Find(x => x.IsSelected);
            if (selectedTab == null) {
                selectedTab = tabs[0];
            }
            Debug.WriteLine("Select Tab : " + selectedTab);

            // Movie
            if (CategoryManager.IsMovieCategory(selectedTab.Type))
            {
                Title = "영화";
            }
            // Books
            else if (CategoryManager.IsBooksCategory(selectedTab.Type))
            {
                Title = "도서";
            }

            BindingContext = viewModel = new ListPageViewModel();

            InitView();
        }

        void InitView()
        {
            MakeTabBar();
        }

        void MakeTabBar()
        {
            List<string> arrTabs = new List<string>();

            int nSelIndex = 0;
            foreach (Tab item in TypeList)
            {
                arrTabs.Add(item.Title);

                if (item.IsSelected) {
                    nSelIndex = TypeList.IndexOf(item);
                }
            }

            TabButton.makeTabLayout(arrTabs, null, nSelIndex);
            TabButton.Listener = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                SelectedCategory(selectedTab);
            }

            pageNumber++;
        }

        #region EventHandler
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ListPageItem;
            if (item == null)
                return;

            // Movie
            if (CategoryManager.IsMovieCategory(selectedTab.Type))
            {
                await Navigation.PushAsync(new DetailPage(item.Id));
            }
            // Books
            else if (CategoryManager.IsBooksCategory(selectedTab.Type))
            {
                await Navigation.PushAsync(new WebviewPage(item.NextPageUrl));
            }
            
            // Manually deselect item
            listView.SelectedItem = null;
        }

        void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = e.Item as ListPageItem;
            int index = viewModel.Items.IndexOf(item);
            if (viewModel.Items.Count - 1 <= index)
            {
                // NextDataReqeust
                NextDataReqeust();
            }
        }

        public void onClickTabButton(int index)
        {
            SelectedCategory(TypeList[index]);
        }
        #endregion

        void SelectedCategory(Tab selectTab)
        {
            if (selectedTab != selectTab) {
                // category 가 변경되었을경우에는 pageNumber를 초기화해준다.
                pageNumber = 1;
                viewModel.Items.Clear();
            }

            selectedTab = selectTab;

            viewModel.SelectedCategoryType = selectedTab.Type;
            viewModel.LoadItemsCommand.Execute(null);
        }

        void NextDataReqeust()
        {
            if (dataLoading || !CategoryManager.IsMovieCategory(selectedTab.Type))
            {
                return;
            }

            dataLoading = true;
            pageNumber++;

            viewModel.MoreItemsCommand.Execute(pageNumber);

            dataLoading = false;
        }
    }
}
