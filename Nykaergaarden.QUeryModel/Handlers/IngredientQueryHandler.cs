using System.Collections.Generic;
using System.Linq;
using Nykaergaarden.QueryModel.Recipes.Model;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL;
using Raven.Client;
using Raven.Client.Linq;

namespace Nykaergaarden.QueryModel.Handlers
{
    public class IngredientQueryHandler : QueryHandler<Ingredient>
    {
        public IngredientQueryHandler(IDocumentStore store) : base(store) { }

        public List<Ingredient> FindByNameStartsWith(string requestName)
        {
            using (var session = Store.OpenSession())
            {
                return session.Query<Ingredient>()
                    .Where(x => x.Name.StartsWith(requestName))
                    .ToList();
            }
        }
    }
}