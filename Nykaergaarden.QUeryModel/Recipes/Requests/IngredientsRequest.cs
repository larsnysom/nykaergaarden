using System;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.QueryModel.Recipes.Requests
{
    [Route("/ingredient/{id*}", "GET")]
    public class IngredientsRequest
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}