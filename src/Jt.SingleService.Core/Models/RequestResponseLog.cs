﻿using Newtonsoft.Json;

namespace Jt.SingleService.Core
{
    public class RequestResponseLog
    {
        public string Url { get; set; }

        [JsonIgnore]
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public string Method { get; set; }

        public string QueryString { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public long ExcuteTime { get; set; }
    }
}
