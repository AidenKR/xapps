using System;

namespace xapps
{
    public class BaseRequestData
    {
        public int requestType { get; set; }        // 규격에 대한 const
        public string api_key = "?api_key=54284155412142a62e518c006e50d5ce";    // key
        public string language = "&language=ko-KR";     // 언어 설정
        public string baseUrl = "";     // primary request url
        public string requestUrl = "";  // adding url to primary
        public string parseType = "";   // parse type( xml, json.... etc )
    }
}
