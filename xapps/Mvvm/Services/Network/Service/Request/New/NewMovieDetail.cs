using System;
namespace xapps
{
    public class NewMovieDetail : NewRequestData
    {
        public static string localeListRestUrl = "http://api.koreafilm.or.kr/openapi-data2/wisenut/search_api/search_xml.jsp?";
        public static string pageNo = "pageNo=";
        public static string numOfRows = "&numOfRows=";
        public static string ServiceKey = "&ServiceKey=";
        public static string movieId = "&movieId=";
    }
}
