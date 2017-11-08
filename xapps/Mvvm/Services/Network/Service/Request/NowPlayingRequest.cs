using System;
namespace xapps
{
    public class NowPlayingRequest
    {
		//https://api.themoviedb.org/3/movie/now_playing?api_key=54284155412142a62e518c006e50d5ce&language=ko_KR&page=1
        public static string localeListRestUrl = "https://api.themoviedb.org/3/movie/now_playing?";
        public static string api_key = "&api_key=54284155412142a62e518c006e50d5ce";
        public static string language = "&language=ko_KR";
        public static string page = "&page=";
    }
}
