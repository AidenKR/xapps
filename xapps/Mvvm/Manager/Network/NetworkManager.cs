
using System.Threading.Tasks;

namespace xapps
{
    public static class NetworkManager
    {
        #region NowPlaying
        /// <summary>
        /// 현재 상영작 리스트를 반환한다.
        /// </summary>
        /// <returns>NowPlayingData</returns>
        /// <param name="page">요청 페이지 번호</param>
        public static Task<NowPlayingData> NowPlaying(string page)
        {
            return MakeApiNowPlaying(page).GetAsync<NowPlayingData>();
        }

        /// <summary>
        /// 현재 상영작 리스트를 반환한다.
        /// 전달 받은 Callback 으로 전달한다.
        /// </summary>
        /// <param name="page">요청 페이지 번호</param>
        /// <param name="callback">응답 받을 Callback</param>
        public static void NowPlayingToCallback(string page, NetworkCallbackDelegate callback)
        {
            MakeApiNowPlaying(page).GetAsyncToCallback<NowPlayingData>(callback);
        }

        static BaseApi MakeApiNowPlaying(string page)
        {
            // Make Parameter
            ApiMovieNowPlaying.ReqParam param = new ApiMovieNowPlaying.ReqParam
            {
                Page = page
            };

            // Make Api
            ApiMovieNowPlaying api = new ApiMovieNowPlaying(param);
            return api;
        }
        #endregion

        #region Upcoming
        public static Task<UpcomingData> Upcoming(string page)
        {
            return MakeApiUpcoming(page).GetAsync<UpcomingData>();
        }

        public static void UpcomingToCallback(string page, NetworkCallbackDelegate callback)
        {
            MakeApiUpcoming(page).GetAsyncToCallback<UpcomingData>(callback);
        }

        static BaseApi MakeApiUpcoming(string page)
        {
            // Make Param
            ApiMovieUpcoming.ReqParam param = new ApiMovieUpcoming.ReqParam
            {
                Page = page
            };

            // Make Api
            ApiMovieUpcoming api = new ApiMovieUpcoming(param);
            return api;
        }
        #endregion Upcoming

        #region Detail
        public static Task<DetailData> Detail(string moveId)
        {
            return MakeApiDetail(moveId).GetAsync<DetailData>();
        }

        public static void DetailToCallback(string moveId, NetworkCallbackDelegate callback)
        {
            MakeApiDetail(moveId).GetAsyncToCallback<DetailData>(callback);
        }

        static BaseApi MakeApiDetail(string moveId)
        {
            // Make Param
            ApiMovieDetail.ReqParam param = new ApiMovieDetail.ReqParam
            {
                MovieId = moveId
            };

            // Make Api
            ApiMovieDetail api = new ApiMovieDetail(param);
            return api;
        }
        #endregion Detail

        #region Credits
        public static Task<CreditsData> Credits(string moveId)
        {
            return MakeApiCredits(moveId).GetAsync<CreditsData>();
        }

        public static void CreditsToCallback(string moveId, NetworkCallbackDelegate callback)
        {
            MakeApiCredits(moveId).GetAsyncToCallback<CreditsData>(callback);
        }

        static BaseApi MakeApiCredits(string moveId)
        {
            // Make Param
            ApiMovieCredits.ReqParam param = new ApiMovieCredits.ReqParam
            {
                MovieId = moveId
            };

            // Make Api
            ApiMovieCredits api = new ApiMovieCredits(param);
            return api;
        }
        #endregion Credits
    }
}
