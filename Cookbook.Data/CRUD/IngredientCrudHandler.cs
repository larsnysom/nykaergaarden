using Nykaergaarden.Cookbook.DomainModel.Model;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL;
using Raven.Client;

namespace Nykaergaarden.Cookbook.DomainModel.CRUD
{
    public class IngredientCrudHandler : CrudHandler<Ingredient>
    {
        public IngredientCrudHandler(IDocumentStore readModel) : base(readModel) { }
    }
}
