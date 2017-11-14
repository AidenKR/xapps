using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace xapps
{
    public class ApiMovieDetail : BaseApi
    {
        ReqParam Param = null;

        public ApiMovieDetail(ReqParam param)
        {
            Param = param;
        }

        protected override string MakeRequestUrl()
        {
            if (Param == null)
            {
                throw new Exception("Request invalide Params. reqParam is NULL.");
            }

            String url = BaseUrl + Param.MovieId + ApiKey + Language;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }

        public class ReqParam
        {
            // movie id.
            public string MovieId { get; set; }
        }
    }
}
