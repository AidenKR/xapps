using System;
namespace xapps
{
    public class DetailsRequest : BaseRequestData
    {
        //https://api.themoviedb.org/3/movie/346364?api_key=54284155412142a62e518c006e50d5ce&language=ko-KR
        public string localeListRestUrl = "https://api.themoviedb.org/3/movie/";

        public string makeRequestUrl(string movieId)
        {
            baseUrl = this.localeListRestUrl;
            requestUrl = movieId + api_key + language;
            return baseUrl + requestUrl;
        }
    }
}
