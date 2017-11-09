using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace xapps
{
    public class RestService : INetService
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
        #region 현재개봉작 요청 - return NowPlayingData
        public async Task<NowPlayingData> requestNowPlayingData(BaseRequestData request)
        {
            string url = request.baseUrl + request.requestUrl;
            Debug.WriteLine(url);

            var uri = new Uri(string.Format(url, string.Empty));
            NowPlayingData playingData = new NowPlayingData(); ;
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine(content);
                    Debug.WriteLine("==========================================================");

                    playingData = (NowPlayingData)this.parseData(request.requestType, content);

                    Debug.WriteLine(playingData);
                }
                else
                {
                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("==================== response Fail =======================");
                    Debug.WriteLine("==========================================================");
                }

                playingData.error_no = (int)response.StatusCode;    // HttpStatusCode
                playingData.error_msg = response.RequestMessage.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            if (playingData == null)
            {

            }

            return playingData;
        }
        #endregion


        #region 상영예정작 요청 - return UpCommingData
        public async Task<UpCommingData> requestUpCommingData(BaseRequestData request)
        {
            string url = request.baseUrl + request.requestUrl;
            Debug.WriteLine(url);

            var uri = new Uri(string.Format(url, string.Empty));
            UpCommingData upCommingData = null;
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("================== response Success ======================");
                    Debug.WriteLine(content);
                    Debug.WriteLine("==========================================================");

                    upCommingData = (UpCommingData)this.parseData(request.requestType, content);
                }
                else
                {
                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("==================== response Fail =======================");
                    Debug.WriteLine("==========================================================");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            if (upCommingData == null)
            {

            }

            return upCommingData;
        }
        #endregion

        #region 상세데이터 요청 - return DetailData
        public async Task<DetailData> requestDetailsData(BaseRequestData request)
        {
            string url = request.baseUrl + request.requestUrl;
            Debug.WriteLine(url);

            var uri = new Uri(string.Format(url, string.Empty));
            DetailData detailData = new DetailData();
            try
            {
                var response = await client.GetAsync(uri);
                Debug.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("================== response Success ======================");
                    Debug.WriteLine(content);
                    Debug.WriteLine("==========================================================");


                    detailData = (DetailData)this.parseData(request.requestType, content);
                }
                else
                {

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("==================== response Fail =======================");
                    Debug.WriteLine("response.StatusCode = " + (int)response.StatusCode);
                    Debug.WriteLine("==========================================================");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            if (detailData == null)
            {

            }

            return detailData;
        }
        #endregion

        #region 상세데이터 요청 - return DetailData
        public async Task<CreditsData> requestCreditsData(BaseRequestData request)
        {
            string url = request.baseUrl + request.requestUrl;
            Debug.WriteLine(url);

            var uri = new Uri(string.Format(url, string.Empty));
            CreditsData creditsData = new CreditsData();
            try
            {
                var response = await client.GetAsync(uri);
                Debug.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("================== response Success ======================");
                    Debug.WriteLine(content);
                    Debug.WriteLine("==========================================================");


                    creditsData = (CreditsData)this.parseData(request.requestType, content);
                }
                else
                {

                    Debug.WriteLine("==========================================================");
                    Debug.WriteLine("==================== response Fail =======================");
                    Debug.WriteLine("response.StatusCode = " + (int)response.StatusCode);
                    Debug.WriteLine("==========================================================");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            if (creditsData == null)
            {

            }

            return creditsData;
        }
        #endregion

        public BaseData parseData(int type, string contents)
        {
            BaseData returnData = null;

            if (contents != "")
            {
                //Converting JSON Array Objects into generic list  
                switch (type)
                {
                    case NetworkRequestConsts.REQUEST_TYPE_NOW_PLAYING:
                        {
                            returnData = JsonConvert.DeserializeObject<NowPlayingData>(contents);
                        }
                        break;

                    case NetworkRequestConsts.REQUEST_TYPE_UP_COMMING:
                        {
                            returnData = JsonConvert.DeserializeObject<UpCommingData>(contents);
                        }
                        break;

                    case NetworkRequestConsts.REQUEST_TYPE_DETAIL:
                        {
                            returnData = JsonConvert.DeserializeObject<DetailData>(contents);
                        }
                        break;

                    case NetworkRequestConsts.REQUEST_TYPE_CREDITS:
                        {
                            returnData = JsonConvert.DeserializeObject<CreditsData>(contents);
                        }
                        break;
                }
            }

            return returnData;
        }

    }
}
