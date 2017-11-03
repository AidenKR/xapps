using System;

namespace xapps
{
    public class MovieList : RequestData
    {
        public static string localeListRestUrl = "http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchDailyBoxOfficeList";
        public static string targetDt = "&targetDt=20170101";
        public static string itemPerPage = "&itemPerPage=10";
    }
}
