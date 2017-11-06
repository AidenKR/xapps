using System;
namespace xapps
{
    public class NewMovieDetail : NewRequestData
    {
        public static string localeListRestUrl = "http://api.koreafilm.or.kr/openapi-data2/wisenut/search_api/search_xml.jsp?collection=kmdb_new&query=korea&detail=Y";    // ?collection=kmdb_new&query=korea&detail=Y
        public static string pageNo = "&pageNo=1";
        public static string numOfRows = "&numOfRows=1";
        public static string ServiceKey = "&ServiceKey=";


        public static string detail = "&detail=Y";
        public static string movieSeq = "&movieSeq=";
        //public static string createDts = "&createDts=20000101";
        //public static string createDte = "&createDte=20170808";
        public static string collection = "&collection=kmdb";
        //public static string startCount = "&startCount=0";
        public static string listCount = "&listCount=1";
    }
}
