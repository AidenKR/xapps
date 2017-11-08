using System;
namespace xapps
{
    public class UpCommingRequest : BaseRequestData
    {
        //https://api.themoviedb.org/3/movie/upcoming?api_key=54284155412142a62e518c006e50d5ce&language=en-US&page=1
        public string localeListRestUrl = "https://api.themoviedb.org/3/movie/upcoming";
        public string page = "&page=";

        public string makeRequestUrl(string page)
        {
            baseUrl = this.localeListRestUrl;
            requestUrl = api_key + language + page + page;
            return baseUrl + requestUrl;
        }
    }
}
