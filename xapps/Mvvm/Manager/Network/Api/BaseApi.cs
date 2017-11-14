using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace xapps
{
    public abstract class BaseApi
    {
        protected const string BaseUrl = "https://api.themoviedb.org/3/movie/"; // 기본 URL

        protected const string ApiKey = "?api_key=54284155412142a62e518c006e50d5ce";    // key
        protected const string Language = "&language=ko-KR";     // 언어 설정

        public async Task<T> GetAsync<T>()
        {
            string url = MakeRequestUrl();

            // 비동기로 Worker Thread에서 도는 Task
            var requestData = Connector.Instance.GetAsync<T>(new Uri(url));

            // Task가 끝나길 기다렸다가 끝나면 결과치를 responseData에 할당
            ResponseData responseData = await requestData;

            Debug.WriteLine("## RESPONSE DATA CODE     : " + responseData.ResponseCode);
            Debug.WriteLine("## RESPONSE DATA MESSAGE  : " + responseData.ResponseMsg);
            Debug.WriteLine("## RESPONSE DATA BODY     : " + responseData.BodyData);

            return (T)responseData.BodyData;
        }

        protected abstract string MakeRequestUrl();
    }
}
