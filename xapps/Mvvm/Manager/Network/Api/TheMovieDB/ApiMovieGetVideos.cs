using System;
using System.Diagnostics;

namespace xapps
{
    public class ApiMovieGetVideos : BaseApi
    {
		ReqParam Param = null;

        public ApiMovieGetVideos(ReqParam param)
        {
            Param = param;
        }

        // https://api.themoviedb.org/3/movie/284053/videos?api_key=54284155412142a62e518c006e50d5ce&language=en-US
        protected override string MakeRequestUrl()
        {
            if (Param == null)
            {
                throw new Exception("Request invalide Params. reqParam is NULL.");
            }

            String url = ConstsMovieApi.BaseUrl + Param.movieId + "/videos" + ConstsMovieApi.ApiKey + ConstsMovieApi.LanguageEn;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }

        public class ReqParam
        {
            public string movieId { get; set; }
        }
    }
}