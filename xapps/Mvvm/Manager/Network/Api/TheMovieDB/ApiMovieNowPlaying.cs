using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace xapps
{
    public class ApiMovieNowPlaying : BaseApi
    {
        ReqParam Param = null;

        public ApiMovieNowPlaying(ReqParam param)
        {
            Param = param;
        }

        protected override string MakeRequestUrl()
        {
            if (Param == null)
            {
                throw new Exception("Request invalide Params. reqParam is NULL.");
            }

            String url = ConstsMovieApi.BaseUrl + "now_playing" + ConstsMovieApi.ApiKey + ConstsMovieApi.Language + Param.Page;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }

        public class ReqParam
        {
            // Param Page.
            string page = "";
            public string Page
            {
                get { return "&page=" + page; }
                set { page = value; }
            }
        }
    }
}
