using System;
using Nykaergaarden.QueryModel.Handlers;
using Nykaergaarden.QueryModel.Recipes.Requests;
using Nykaergaarden.SharedKernel.Infrastructure.Services;

namespace Nykaergaarden.QueryInterface
{
    public class QueryService : ServiceBase
    {
        private readonly IngredientQueryHandler _ingredientsHandler;

        public QueryService(IngredientQueryHandler ingredientHandler)
        {
            _ingredientsHandler = ingredientHandler;
        }

        public object Get(IngredientsRequest request)
        {
            object result = null;
            if (request.Id.HasValue)
            {
                result = _ingredientsHandler.FindById(request.Id.Value);
            }
            else if (request.Name != null)
            {
                result = _ingredientsHandler.FindByNameStartsWith(request.Name);
            }
            else
            {
                result = _ingredientsHandler.FindAll();
            }
            return result;
        }

        public object Get(RecipeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}