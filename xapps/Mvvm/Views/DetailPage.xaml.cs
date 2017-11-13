using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using xapps.Mvvm.Views.CustomTabBar;

namespace xapps
{
    public partial class DetailPage : ContentPage , CustomTabInterface
    {
        private DetailPageViewModel viewModel;
        private string mRequestId;

        public DetailPage(String reqId)
        {
            InitializeComponent();

            mRequestId = reqId;
            printLog("reqServerData reqId : " + mRequestId);

            BindingContext = viewModel = new DetailPageViewModel(mRequestId);
            initView();
        }

        private void initView() {

            // TAB
            List<CustomTabData> tabs = new List<CustomTabData>();
            CustomTabData tab = new CustomTabData();
            tab.tabText = "평점";
            tab.isUseImage = false;
            tab.selColor = "#F7D358";
            tab.norColor = "#F5ECCE";
            tab.tag = "1";
            tabs.Add(tab);
            CustomTabData tab2 = new CustomTabData();
            tab2.tabText = "포토/트레일러";
            tab2.isUseImage = false;
            tab2.selColor = "#F7D358";
            tab2.norColor = "#F5ECCE";
            tab2.tag = "2";
            tabs.Add(tab2);
            CustomTabData tab3 = new CustomTabData();
            tab3.tabText = "감독/배우";
            tab3.isUseImage = false;
            tab3.selColor = "#F7D358";
            tab3.norColor = "#F5ECCE";
            tab3.tag = "3";
            tabs.Add(tab3);
            CustomTabView tabView = new CustomTabView(this, mdpTab.Width);
            tabView.makeTabLayout(tabs);
            mdpTab.Children.Add(tabView);
        }

        async void onClickFullMoviePage(object sender, System.EventArgs e)
        {
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
            await Navigation.PushAsync(new PreviewPage());
        }

        void onClickMovieStoryMore(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            bool btnVisible = btn.IsVisible;

            mdpMovieInfoBtnMore.IsVisible = false;
            mdpMovieInfoTvStory.LineBreakMode = LineBreakMode.WordWrap;
        }

        private void printLog(string msg)
        {
            Debug.WriteLine("################### " + msg);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DetailItem == null)
                viewModel.LoadItemsCommand.Execute(mRequestId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public void onClickTabButton(object index)
        {
            // Event
        }
    }
}
