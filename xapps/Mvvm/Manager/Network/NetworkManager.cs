//#define USE_PARSE_XML

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xapps
{
	public class NetworkManager
	{
        public static Task<NowPlayingData> ReqNowPlaying(string page) {
            // Make Parameter
            ApiMovieNowPlaying.ReqParam param = new ApiMovieNowPlaying.ReqParam();
            param.Page = page;

            // Request
            ApiMovieNowPlaying api = new ApiMovieNowPlaying(param);
            return api.GetAsync<NowPlayingData>();
        }

        public static Task<UpCommingData> ReqUpComming(string page) {
            // Make Parameter
            ApiMovieUpcoming.ReqParam param = new ApiMovieUpcoming.ReqParam();
            param.Page = page;

            // Request
            ApiMovieUpcoming api = new ApiMovieUpcoming(param);
            return api.GetAsync<UpCommingData>();
        }

        public static Task<DetailData> ReqDetail(string movieId) {
            // Make Parameter
            ApiMovieDetail.ReqParam param = new ApiMovieDetail.ReqParam();
            param.MovieId = movieId;

            // Request
            ApiMovieDetail api = new ApiMovieDetail(param);
            return api.GetAsync<DetailData>();
        }

        public static Task<CreditsData> requestCreditsData(string movieId) {
            // Make Parameter
            ApiMovieCredits.ReqParam param = new ApiMovieCredits.ReqParam();
            param.MovieId = movieId;

            // Request
            ApiMovieCredits api = new ApiMovieCredits(param);
            return api.GetAsync<CreditsData>();
        }
	}
}
