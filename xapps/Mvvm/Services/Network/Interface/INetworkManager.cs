using System;
namespace xapps
{
    public interface INetworkManager
    {
        void onSuccess(BaseData data);
        void onFail(BaseData data);
    }
}
