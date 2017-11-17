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

        public void onClickTabButton(object index)
        {
            Debug.WriteLine("Tab Selected Index : " + index);

            int type = ListPageViewModel.TYPE_NOW_PLAYING;
            if (Convert.ToInt32(index) != 0)
            {
                type = ListPageViewModel.TYPE_UPCOMING;
            }
            Navigation.PushAsync(new ListPage(type));
        }
    }
}
