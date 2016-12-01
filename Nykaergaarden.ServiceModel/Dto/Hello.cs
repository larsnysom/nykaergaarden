using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nykaergaarden.ServiceModel.Dto
{
    [Route("/hello/{name}", "GET")]
    public class HelloRequest
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Greeting { get; set; }
    }
}
