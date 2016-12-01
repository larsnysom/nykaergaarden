using System.Web.Mvc;
using Nykaergaarden.QueryModel.Handlers;
using Nykaergaarden.Web.ViewModels;
using ServiceStack.Mvc;

namespace Nykaergaarden.Web.Controllers
{
    public class HomeController : ServiceStackController
    {
        private readonly IngredientQueryHandler _ingredientHandler;
        private readonly RecipeQueryHandler _recipeHandler;

        public HomeController(IngredientQueryHandler ingredientHandler, RecipeQueryHandler recipeHandler)
        {
            _ingredientHandler = ingredientHandler;
            _recipeHandler = recipeHandler;
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                Ingredients = _ingredientHandler.FindAll(), 
                Recipes = _recipeHandler.FindAll()
            };
            return View(model);
        }
    }
}