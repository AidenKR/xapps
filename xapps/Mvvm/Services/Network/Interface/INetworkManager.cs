using System.Threading.Tasks;
using System.Collections.Generic;

namespace xapps
{
	public interface INetworkManager
	{
        Task<NowPlayingData> requestNowPlayingData(BaseRequestData request);

        Task<UpCommingData> requestUpCommingData(BaseRequestData request);

        Task<DetailData> requestDetailsData(BaseRequestData request);
	}
}
