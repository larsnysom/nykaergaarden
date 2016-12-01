using System;
using System.Collections.Generic;

namespace Audit.Model
{
    public class Request
    {
        public DateTime Received { get; set; }

        public string Url { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public Response Response { get; set; }
    }
}