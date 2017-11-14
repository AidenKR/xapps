using System;

namespace xapps
{
    public struct ResponseData
    {
        // 서버 응답 메시지. Error의 경우 Error Message.
        public string ResponseMsg { get; set; }

        // Server 응답 코드.
        public int ResponseCode { get; set; }

        // 서버 응답 결과 Data 
        public Object BodyData { get; set; } 
    }
}
