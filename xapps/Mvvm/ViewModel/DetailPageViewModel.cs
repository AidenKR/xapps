using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class DetailPageViewModel : BaseViewModel, INetworkManager
    {
        private string IMAGE_PATH = "https://image.tmdb.org/t/p/w500";
        public DetailData Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public DetailPageViewModel(string requestId)
        {
            Title = "상세화면";
            Items = new DetailData();

            if (string.IsNullOrWhiteSpace(requestId))
            {
                return;
            }

            LoadItemsCommand = new Command(async () => await ExecuteLoadDetailItemsCommand(requestId));
        }

        async Task ExecuteLoadDetailItemsCommand(string reqId)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items = await NetworkManager.Instance().requestDetailsData(reqId);
                printLog(Items.ToString());

                Items.poster_path = IMAGE_PATH + Items.poster_path;
                Items.backdrop_path = IMAGE_PATH + Items.backdrop_path;

                Items.runtime = Items.runtime + "분";

                //string genre;
                //if (null != Items.genres) {
                //    foreach (genres in Items.genres) {
                        
                //    }
                ////* " + Items.genre;
                //}
                //if (!string.IsNullOrWhiteSpace(Items.rating)) {
                //    Items.runtime += " * " + Items.rating;
                //}

                OnPropertyChanged();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void initData()
        {
            // set item
            //string urlPoster = mData.posters;
            //string urlBg = mData.posters;
            //string txtMovieTitle = mData.title;
            //string txtMovieDesc = mData.runtime + "분 * " + mData.genre;
            //if (!string.IsNullOrWhiteSpace(mData.rating)) {
            //    txtMovieDesc += " * " + mData.rating;
            //}
            //string txtMovieStory = mData.plot;
            //string stateNowPlaying = getNowPlayState(mData.repRlsDate);
            //string txtNowPlayingAdvanceRate = "25.5%";
            //string txtNowPlayingReleaseDate = string.IsNullOrWhiteSpace(mData.repRlsDate) ? "개봉 미정" : mData.repRlsDate + " 개봉";

            //// set view
            //setImage(mdpMovieImageIvPoster, urlPoster);
            //setImage(mdpMovieImageIvBg, urlBg);

            //mdpNowPlayingTvState.Text = stateNowPlaying;
            //mdpNowPlayingTvAdvanceRate.Text = txtNowPlayingAdvanceRate;
            //mdpNowPlayingTvReleaseDate.Text = txtNowPlayingReleaseDate;

            //mdpMovieInfoTvTitle.Text = txtMovieTitle;
            //mdpMovieInfoTvDesc.Text = txtMovieDesc;
            //mdpMovieInfoTvStory.Text = txtMovieStory;

            //setPerformerListData();
        }

        public void onSuccess(BaseData data)
        {
            printLog("onSuccess()");
        }

        public void onFail(BaseData data)
        {
            printLog("onFail()");
        }

        private void printLog(string msg)
        {
            Debug.WriteLine("##### " + msg);
        }
    }
}
