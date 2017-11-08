using System;
namespace xapps
{
    public class NowPlayingRequest : RequestData
    {
		//https://api.themoviedb.org/3/movie/now_playing?api_key=54284155412142a62e518c006e50d5ce&language=ko_KR&page=1
        public static string localeListRestUrl = "https://api.themoviedb.org/3/movie/now_playing";
        public static string page = "&page=";
    }
}
