using System;
namespace xapps
{
    public struct ConstsMovieApi
    {
        public const string BaseUrl = "https://api.themoviedb.org/3/movie/"; // 기본 URL

        public const string ApiKey = "?api_key=54284155412142a62e518c006e50d5ce";    // key
        public const string Language = "&language=ko-KR";     // 언어 설정
        public const string LanguageEn = "&language=en-US";     // 언어 설정(영어)
    }
}
