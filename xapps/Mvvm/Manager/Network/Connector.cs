using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace xapps
{
    // 병렬처리가 필요한 경우 Connector를 매번 생성해야 한다.
    public class Connector
    {
        static HttpClient client;

        Connector()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        static Connector instance;
        public static Connector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connector();
                }
                return instance;
            }
        }

        async public Task<ResponseData> GetAsync<T>(Uri uri)
        {
            ResponseData responseData = new ResponseData();

            var result = await client.GetAsync(uri);

            if (result.IsSuccessStatusCode)
            {
                responseData.ResponseCode = 0;
                responseData.ResponseMsg = "Success.";

                string content = await result.Content.ReadAsStringAsync();

                // Parsing
                responseData.BodyData = JsonConvert.DeserializeObject<T>(content);

                Debug.WriteLine("==================== [ SUCCESS ] =========================");
                Debug.WriteLine(content);
                Debug.WriteLine("==========================================================");
            }
            else
            {
                // TODO Error Code 정의 후 처리 필요.
                responseData.ResponseCode = -1;
                responseData.ResponseMsg = result.RequestMessage.ToString();

                Debug.WriteLine("====================== [ FAIL ] ==========================");
                Debug.WriteLine(responseData.ResponseMsg);
                Debug.WriteLine("==========================================================");
            }

            Debug.WriteLine("## RESPONSE DATA CODE     : " + responseData.ResponseCode);
            Debug.WriteLine("## RESPONSE DATA MESSAGE  : " + responseData.ResponseMsg);
            Debug.WriteLine("## RESPONSE DATA BODY     : " + responseData.BodyData);

            return responseData;
        }

        public void GetAsyncToCallback<T>(Uri uri, NetworkCallbackDelegate iCallback)
        {
            Task.Run(async() =>
            {
                ResponseData responseData = await GetAsync<T>(uri);

                iCallback(responseData);
            });
        }
    }
}
