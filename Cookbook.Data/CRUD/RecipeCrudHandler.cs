using Nykaergaarden.Cookbook.DomainModel.Model;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL;
using Raven.Client;

namespace Nykaergaarden.Cookbook.DomainModel.CRUD
{
    public class RecipeCrudHandler : CrudHandler<Recipe>
    {
        public RecipeCrudHandler(IDocumentStore model) : base(model) { }
    }
}