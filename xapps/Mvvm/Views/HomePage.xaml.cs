using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class HomePage : ContentPage, CustomTabInterface
    {
        public HomePage()
        {
            InitializeComponent();

            initView();
        }

        void initView()
        {
            // TAB
            setTabBar();
        }

        void setTabBar()
        {
            string[] tabs = { "현재 상영작", "개봉 예정작" };

            const string SelColor = "#F7D358";
            const string NorColor = "#F5ECCE";

            List<CustomTabData> arrTabs = new List<CustomTabData>();

            foreach (string item in tabs)
            {
                CustomTabData tab = new CustomTabData();
                tab.tabText = item;
                tab.selColor = Color.FromHex(SelColor);
                tab.norColor = Color.FromHex(NorColor);

                arrTabs.Add(tab); // Add
            }

            mdpTab.makeTabLayout(arrTabs);
            mdpTab.Listener = this;
        }

        public void onClickTabButton(object index)
        {
            Debug.WriteLine("Tab Selected Index : " + index);

            int type = ListPageViewModel.TYPE_NOW_PLAYING;
            if (Convert.ToInt32(index) != 0) {
                type = ListPageViewModel.TYPE_UPCOMING;
            }
            Navigation.PushAsync(new ListPage(type));
        }
    }
}
