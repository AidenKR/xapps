using System;
namespace xapps
{
    public class CreditsRequest : BaseRequestData
    {
        //https://api.themoviedb.org/3/movie/ 346364/credits?api_key=54284155412142a62e518c006e50d5ce
        public string localeListRestUrl = "https://api.themoviedb.org/3/movie/";

        public string makeRequestUrl(string movieId)
        {
            baseUrl = this.localeListRestUrl;
            requestUrl = movieId + "/credits" + api_key;
            return baseUrl + requestUrl;
        }
    }
}
