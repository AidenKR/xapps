using System;
namespace xapps
{
    public class ProtocolFactory
    {
        public static BaseRequestData findReqeustObject(int type)
        {
            BaseRequestData data = new BaseRequestData();
            //data.requestType = type;
            switch (type)
            {
                case NetworkConsts.REQUEST_TYPE_NOW_PLAYING :
                    {
                        data = new NowPlayingRequest();
                        return data;
                    }

                case NetworkConsts.REQUEST_TYPE_UP_COMMING:
                    {
                        data = new UpCommingRequest();
                        return data;
                    }

                case NetworkConsts.REQUEST_TYPE_DETAIL:
                    {
                        data = new DetailsRequest();
                        return data;
                    }
            }

            return data;
        }
    }
}
