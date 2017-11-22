using System;
using System.Diagnostics;

namespace xapps
{
    public class ApiBooksNewBook : BaseApi
    {
        protected override string MakeRequestUrl()
        {
            String url = ConstsBooksApi.BaseUrl + "/newBook.api" + ConstsBooksApi.ApiKey + ConstsBooksApi.DefaultSetting;

            Debug.WriteLine("## Req URL : " + url);

            return url;
        }
    }
}
