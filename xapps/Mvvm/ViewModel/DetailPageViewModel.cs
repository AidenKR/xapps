using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class DetailPageViewModel : BaseViewModel, INetworkManager
    {
        private static readonly string IMAGE_PATH = "https://image.tmdb.org/t/p/w500";

        public Command LoadItemsCommand { get; set; }

        DetailData item;
        public DetailData DetailItem
        {
            set
            {
                if (item != value)
                {
                    item = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return item;
            }
        }

        public DetailPageViewModel(string requestId)
        {
            Title = "상세화면";

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
                DetailData data = await NetworkManager.Instance().requestDetailsData(reqId);
                printLog(data.ToString());

                data.poster_path = IMAGE_PATH + data.poster_path;
                data.backdrop_path = IMAGE_PATH + data.backdrop_path;

                data.runtime = data.runtime + "분";


                DetailItem = data;
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
