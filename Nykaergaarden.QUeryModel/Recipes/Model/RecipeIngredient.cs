using Raven.Client.Connection.Async;

namespace Nykaergaarden.QueryModel.Recipes.Model
{
    public class RecipeIngredient
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

    }
}