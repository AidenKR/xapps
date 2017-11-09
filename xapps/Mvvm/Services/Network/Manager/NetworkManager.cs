using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xapps
{
	public class NetworkManager
	{
        private INetService iNetService;
        //private INetworkManager iNetworkManager;
        private static readonly object _lockObj = new object();
        private static NetworkManager netManager = null;
        private NetworkManager(INetService service)
        {
            iNetService = service;
        }

        static internal NetworkManager Instance() //INetworkManager iNetMgr)
        {
            // can thread safety
            lock (_lockObj)
            {
                if (netManager == null)
                {
                    netManager = new NetworkManager(new RestService());
                }

                //netManager.iNetworkManager = iNetMgr;
                return netManager;
            }
        }

        public Task<NowPlayingData> requestNowPlayingData(string page) {
            NowPlayingRequest data = (NowPlayingRequest)ProtocolFactory.findReqeustObject(NetworkConsts.REQUEST_TYPE_NOW_PLAYING);
            data.requestType = NetworkConsts.REQUEST_TYPE_NOW_PLAYING;
            data.makeRequestUrl(page);

            //if(iNetworkManager != null) {
            //    var result = await iNetService.requestNowPlayingData(data);
            //    if(result.error_no >= 200 && result.error_no < 300) {
            //        iNetworkManager.onSuccess(result);
            //    } else {
            //        iNetworkManager.onFail(result);
            //    }
            //}

            return iNetService.requestNowPlayingData(data);
        }

        public Task<UpCommingData> requestUpCommingData(string page) {
            UpCommingRequest data = (UpCommingRequest)ProtocolFactory.findReqeustObject(NetworkConsts.REQUEST_TYPE_UP_COMMING);
            data.requestType = NetworkConsts.REQUEST_TYPE_UP_COMMING;
            data.makeRequestUrl(page);
            return iNetService.requestUpCommingData(data);
        }

        public Task<DetailData> requestDetailsData(string movieId) {
            DetailsRequest data = (DetailsRequest)ProtocolFactory.findReqeustObject(NetworkConsts.REQUEST_TYPE_DETAIL);
            data.requestType = NetworkConsts.REQUEST_TYPE_DETAIL;
            data.makeRequestUrl(movieId);
            return iNetService.requestDetailsData(data);
        }
	}
}
