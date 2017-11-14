using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace xapps
{
    public class Connector
    {
        private static HttpClient client;

        private Connector()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        private static Connector instance;
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
                // TODO Error Code 정의 후 처리 필.
                responseData.ResponseCode = -1;
                responseData.ResponseMsg = result.RequestMessage.ToString();

                Debug.WriteLine("====================== [ FAIL ] ==========================");
                Debug.WriteLine(responseData.ResponseMsg);
                Debug.WriteLine("==========================================================");
            }

            return responseData;
        }
    }
}
