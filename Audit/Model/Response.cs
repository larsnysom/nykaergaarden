using System;

namespace Audit.Model
{
    public class Response
    {
        public DateTime Sent { get; set; }

        public object Result { get; set; }
    }
}