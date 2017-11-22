using System;
using System.Diagnostics;

namespace xapps
{
    public class ApiBooksRecommend : BaseApi
    {
        protected override string MakeRequestUrl()
        {
            String url = ConstsBooksApi.BaseUrl + "/recommend.api" + ConstsBooksApi.ApiKey + ConstsBooksApi.DefaultSetting;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }
    }
}
