using System;
using System.Collections.Generic;

namespace Audit.Model
{
    public class Session
    {
        public string ApplicationName { get; set; }

        public Guid SessionId { get; set; }

        public DateTime Started { get; set; }

        public List<Request> Requests { get; set; }        
    }
}