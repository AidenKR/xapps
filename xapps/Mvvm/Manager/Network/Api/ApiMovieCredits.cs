using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace xapps
{
    public class ApiMovieCredits : BaseApi
    {
        ReqParam Param = null;

        public ApiMovieCredits(ReqParam param)
        {
            Param = param;
        }

        protected override string MakeRequestUrl()
        {
            if (Param == null)
            {
                throw new Exception("Request invalide Params. reqParam is NULL.");
            }

            String url = BaseUrl + Param.MovieId + "/credits" + ApiKey;

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
