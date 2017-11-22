using System;
using System.Diagnostics;

namespace xapps
{
    public class ApiBooksRecommand : BaseApi
    {
        protected override string MakeRequestUrl()
        {
            String url = ConstsBooksApi.BaseUrl + "/recommand.api" + ConstsBooksApi.ApiKey + ConstsBooksApi.DefaultSetting;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }
    }
}
