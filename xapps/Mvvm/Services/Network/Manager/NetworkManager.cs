using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xapps
{
	public class NetworkManager
	{
        private INetworkManager iNetworkManager;

        //public Task<MovieListData> requestMovieList()
        //{
        //    return iNetworkManager.requestMovieList();
        //}

        //public Task <MovieDetailData> requestMovieDetail(String movieCd)
        //{
        //    return iNetworkManager.requestMovieDetail(movieCd);
        //}

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

        public Task<List<MovieData>> requestMovieList()
        {
            return iNetworkManager.requestMovieList();
        }

        public Task<MovieData> requestMovieDetail(String movieSeq)
        {
            return iNetworkManager.requestMovieDetail(movieSeq);
        }
	}
}
