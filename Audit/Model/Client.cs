using System;
using System.Collections.Generic;

namespace Audit.Model
{
    public class Client
    {
        public string Username { get; set; }

        public string IpAddress { get; set; }

        public List<Session> Sessions { get; set; }
    }
}