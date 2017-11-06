using System;
namespace xapps
{
    public class NewMovieList : NewRequestData
    {
        public static string localeListRestUrl = "http://api.koreafilm.or.kr/openapi-data2/wisenut/search_api/search_xml.jsp?";    // ?collection=kmdb_new&query=korea&detail=Y
        public static string pageNo = "pageNo=";
        public static string numOfRows = "&numOfRows=";
        public static string ServiceKey = "&ServiceKey=";
    }
}