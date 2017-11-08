#define USE_PARSE_XML

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace xapps
{
    public class RestService : INetworkManager
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

//        public async Task<List<MovieData>> requestMovieList() {
//#if USE_PARSE_XML
//            string url = MovieDataListRequest.localeListRestUrl + MovieDataListRequest.pageNo + MovieDataListRequest.numOfRows + MovieDataListRequest.ServiceKey + MovieDataListRequest.key
//                                             + MovieDataListRequest.detail + MovieDataListRequest.createDts + MovieDataListRequest.createDte + MovieDataListRequest.startCount + MovieDataListRequest.listCount;

//#else
//            string url = NewMovieList.localeListRestUrl + NewMovieList.responseType_json + NewMovieList.key;
//#endif

//            Debug.WriteLine(url);
//            var uri = new Uri(string.Format(url, string.Empty));
//            List<MovieData> item = new List<MovieData>();
//            try
//            {
//                var response = await client.GetAsync(uri);
//                if (response.IsSuccessStatusCode)
//                {
//                    var content = await response.Content.ReadAsStringAsync();

//                    Debug.WriteLine("==========================================================");
//                    Debug.WriteLine(content);
//                    Debug.WriteLine("==========================================================");
//#if USE_PARSE_XML
//                    MovieDataListParser parser = new MovieDataListParser();
//                    item = parser.parseXml(content);
//#else
//                    items = JsonConvert.DeserializeObject<MovieDetailItem>(content);
//#endif
//                }
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(@"ERROR {0}", ex.Message);
//}

//            return item;
//        }

//        public async Task<MovieData> requestMovieDetail(string movieSeq) {
//#if USE_PARSE_XML
//            string url = MovieDataRequest.localeListRestUrl + MovieDataRequest.pageNo + MovieDataRequest.numOfRows + MovieDataRequest.ServiceKey + MovieDataRequest.key
//                                         + MovieDataRequest.detail + MovieDataRequest.listCount + MovieDataRequest.movieSeq + movieSeq;
//#else
//            string url = NewMovieList.localeListRestUrl + NewMovieList.responseType_json + NewMovieList.key;
//#endif

//            Debug.WriteLine(url);
//            var uri = new Uri(string.Format(url, string.Empty));
//            MovieData item = new MovieData();
//            try
//            {
//                var response = await client.GetAsync(uri);
//                if (response.IsSuccessStatusCode)
//                {
//                    var content = await response.Content.ReadAsStringAsync();

//                    Debug.WriteLine("==========================================================");
//                    Debug.WriteLine(content);
//                    Debug.WriteLine("==========================================================");
//#if USE_PARSE_XML
//                    MovieDataParser parser = new MovieDataParser();
//                    item = parser.parseXml(content);
//#else
//                    items = JsonConvert.DeserializeObject<MovieDetailItem>(content);
//#endif
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"ERROR {0}", ex.Message);
        //    }

        //    return item;
        //}

        public async Task<NowPlayingData> requestNowPlayingData(string page)
        {
            string url = NowPlayingRequest.localeListRestUrl + NowPlayingRequest.api_key + NowPlayingRequest.language + NowPlayingRequest.page + page;
            Debug.WriteLine(url);

            var uri = new Uri(string.Format(url, string.Empty));
            List<NowPlayingData> playing = new List<NowPlayingData>();
            NowPlayingData playingData = new NowPlayingData();  
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine(content);
                    Debug.WriteLine("==========================================================");


                    if (content != "")  
                    {  
                        //Converting JSON Array Objects into generic list  
                        playingData = JsonConvert.DeserializeObject<NowPlayingData>(content);  
                    }

                    Debug.WriteLine(playingData);
                } else {
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return playingData;
        }

        public async Task<NowPlayingData> requestUpCommingData(string page)
        {
            string url = NowPlayingRequest.localeListRestUrl + NowPlayingRequest.api_key + NowPlayingRequest.language + NowPlayingRequest.page + page;
            Debug.WriteLine(url);

            var uri = new Uri(string.Format(url, string.Empty));
            List<NowPlayingData> playing = new List<NowPlayingData>();
            NowPlayingData playingData = new NowPlayingData();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine(content);
                    Debug.WriteLine("==========================================================");


                    if (content != "")
                    {
                        //Converting JSON Array Objects into generic list  
                        playingData = JsonConvert.DeserializeObject<NowPlayingData>(content);
                    }

                    Debug.WriteLine(playingData);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return playingData;
        }
    }
}
