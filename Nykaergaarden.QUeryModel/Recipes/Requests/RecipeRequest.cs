using System;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.QueryModel.Recipes.Requests
{
    [Route("/recipe/{id*}", "GET")]
    public class RecipeRequest
    {
        public Guid? Id { get; set; }
    }
}