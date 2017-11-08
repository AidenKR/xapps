using System;
namespace xapps
{
    public class NowPlayingRequest : BaseRequestData
    {
		//https://api.themoviedb.org/3/movie/now_playing?api_key=54284155412142a62e518c006e50d5ce&language=ko_KR&page=1
        public string localeListRestUrl = "https://api.themoviedb.org/3/movie/now_playing";
        public string page = "&page=";

        public void makeRequestUrl(string page)
        {
            baseUrl = this.localeListRestUrl;
            requestUrl = api_key + language + page + page;
            //return baseUrl + requestUrl;
        }
    }
}
