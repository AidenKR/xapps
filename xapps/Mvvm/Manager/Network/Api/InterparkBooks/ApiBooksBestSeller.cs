using System;
using System.Diagnostics;

namespace xapps
{
    public class ApiBooksBestSeller : BaseApi
    {
        protected override string MakeRequestUrl()
        {
            String url = ConstsBooksApi.BaseUrl + "/bestSeller.api" + ConstsBooksApi.ApiKey + ConstsBooksApi.DefaultSetting;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }
    }
}
