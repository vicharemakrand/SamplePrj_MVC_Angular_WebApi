using System.Collections.Generic;

namespace Sample.ServiceResponse
{
    public class BaseResponseResult
    {
        public string Message { get; set; }
        public bool IsSucceed { get; set; }
        public Dictionary<string, string> OtherInfo { get; set; }

    }
}
