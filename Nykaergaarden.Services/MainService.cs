using Nykaergaarden.ServiceModel.Dto;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nykaergaarden.Services
{
    public class HelloService : Service
    {
        public object Any(HelloRequest request)
        {
            return "Hello world";
        }
    }
}
