using System.Threading.Tasks;
using System.Collections.Generic;

namespace xapps
{
	public interface INetworkManager
	{
        Task<NowPlayingData> requestNowPlayingData(string page);
	}
}
