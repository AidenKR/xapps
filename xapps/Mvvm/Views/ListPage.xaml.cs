using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class ListPage : ContentPage, CustomTabInterface
    {
        class Tab
        {
            public string Title { get; set; }
            public int Type { get; set; }
        }

        List<Tab> TypeList = new List<Tab>(){
            new Tab{ Title = "현재 상영작", Type = ListPageViewModel.TYPE_NOW_PLAYING },
            new Tab{ Title = "개봉 예정작", Type = ListPageViewModel.TYPE_UPCOMING }
        };

        ListPageViewModel viewModel;

        int selectIndex = 0;
        int pageNumber = 0;
        bool dataLoading;

        public ListPage(int type = ListPageViewModel.TYPE_NOW_PLAYING)
        {
            InitializeComponent();

            selectIndex = TypeList.FindIndex( (obj) => obj.Type == type );
            Debug.WriteLine("Select Type : " + selectIndex);

            BindingContext = viewModel = new ListPageViewModel();

            InitView();
        }

        void InitView()
        {
            setTabBar();
        }

        void setTabBar()
        {
            List<string> arrTabs = new List<string>();

            foreach (Tab item in TypeList)
            {
                arrTabs.Add(item.Title);
            }

            TabButton.makeTabLayout(arrTabs, null, selectIndex);
            TabButton.Listener = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                SelectedCategory(selectIndex);
            }

            pageNumber++;
        }

        #region EventHandler
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

        public void onClickTabButton(object index)
        {
            SelectedCategory(Convert.ToInt32(index));
        }
        #endregion

        private void SelectedCategory(int index)
        {
            if (selectIndex != index) {
                // category 가 변경되었을경우에는 pageNumber를 초기화해준다.
                pageNumber = 1;
                viewModel.Items.Clear();
            }

            selectIndex = index;

            viewModel.LoadItemsCommand.Execute(TypeList[index].Type);
        }

        void NextDataReqeust()
        {
            if (dataLoading)
            {
                return;
            }

            dataLoading = true;
            pageNumber++;
            int[] reqValues = { TypeList[selectIndex].Type, pageNumber };

            viewModel.MoreItemsCommand.Execute(reqValues);

            dataLoading = false;
        }
    }
}
