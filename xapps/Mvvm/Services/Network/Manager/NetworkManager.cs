using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xapps
{
	public class NetworkManager
	{
        private INetworkManager iNetworkManager;
        private static readonly object _lockObj = new object();
        private static NetworkManager netManager = null;
        private NetworkManager(INetworkManager service)
        {
            iNetworkManager = service;
        }

        static internal NetworkManager Instance()
        {
            // can thread safety
            lock (_lockObj)
            {
                if (netManager == null)
                {
                    netManager = new NetworkManager(new RestService());
                }
                return netManager;
            }
        }

        public Task<NowPlayingData> requestNowPlayingData(string page) {
            return iNetworkManager.requestNowPlayingData(page);
        }

        public Task<UpCommingData> requestUpCommingData(string page) {
            return iNetworkManager.requestUpCommingData(page);
        }

        public Task<DetailData> requestDetailsData(string movieId) {
            return iNetworkManager.requestDetailsData(movieId);
        }
	}
}
