using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class DetailPage : ContentPage
    {
        private DetailPageViewModel viewModel;
        private string mRequestId;

        public DetailPage(String reqId)
        {
            InitializeComponent();

            mRequestId = reqId;
            printLog("reqServerData reqId : " + mRequestId);

            BindingContext = viewModel = new DetailPageViewModel(mRequestId);
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

    }
}
