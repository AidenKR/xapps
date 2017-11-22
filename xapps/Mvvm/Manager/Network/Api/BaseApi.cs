using System;
using System.Threading.Tasks;

namespace xapps
{
    public abstract class BaseApi
    {
        public async Task<T> GetAsync<T>()
        {
            string url = MakeRequestUrl();

            // 비동기로 Worker Thread에서 도는 Task
            var requestData = Connector.Instance.GetAsync<T>(new Uri(url));

            // Task가 끝나길 기다렸다가 끝나면 결과치를 responseData에 할당
            ResponseData responseData = await requestData;

            // Data Parsing Failed.
            if (responseData.BodyData == null)
            {
                return default(T);
            }

            return (T)responseData.BodyData;
        }

        public void GetAsyncToCallback<T>(NetworkCallbackDelegate callback)
        {
            string url = MakeRequestUrl();

            Connector.Instance.GetAsyncToCallback<T>(new Uri(url), callback);
        }

        protected abstract string MakeRequestUrl();
    }
}
