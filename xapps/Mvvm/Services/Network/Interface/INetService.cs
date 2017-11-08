using System;
using System.Threading.Tasks;

namespace xapps
{
    public interface INetService
    {
        Task<NowPlayingData> requestNowPlayingData(BaseRequestData request);

        Task<UpCommingData> requestUpCommingData(BaseRequestData request);

        Task<DetailData> requestDetailsData(BaseRequestData request);

    }
}
