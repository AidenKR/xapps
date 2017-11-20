using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class DetailPage : ContentPage, CustomTabInterface
    {
        private DetailPageViewModel viewModel;
        private string mRequestId;

        public DetailPage(string reqId)
        {
            InitializeComponent();

            mRequestId = reqId;
            printLog("reqServerData reqId : " + mRequestId);

            BindingContext = viewModel = new DetailPageViewModel(mRequestId);
            initView();
        }

        private void initView()
        {
            // TAB
            setTabBar(mdpTab);
        }

        private void setTabBar(StackLayout layout)
        {
            List<string> arrTabs = new List<string> { "평점", "포토/트레일러", "감독/배우" };
            CustomTabCellLayoutData tabLayout = new CustomTabCellLayoutData
            {
                selColor = Color.FromHex("#F7D358"),
                norColor = Color.FromHex("#F5ECCE")
            };

            mdpTab.makeTabLayout(arrTabs, tabLayout);
        }

        void onClickFullMoviePage(object sender, System.EventArgs e)
        {
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
            //await Navigation.PushAsync(new PreviewPage());
            MoviePreviewRenderer.IsVisible = true;
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
            printLog("onClickTabButton() index : " + index);
        }
    }
}
