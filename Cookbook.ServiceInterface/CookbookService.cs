using System;
using System.Collections.Generic;
using System.Linq;
using Nykaergaarden.Cookbook.DomainModel.CRUD;
using Nykaergaarden.Cookbook.DomainModel.Model;
using Nykaergaarden.Cookbook.ServiceModel.Commands;
using Nykaergaarden.QueryModel.Handlers;
using Nykaergaarden.SharedKernel.Infrastructure.Services;

namespace Nykaergaarden.Cookbook.ServiceInterface
{
    public class CookbookService : ServiceBase
    {
        private readonly IngredientQueryHandler _ingredientQueryHandler;
        private readonly IngredientCrudHandler _ingredientHandler;
        private readonly RecipeCrudHandler _recipeHandler;

        public CookbookService(IngredientCrudHandler ingredientCommandHandler, RecipeCrudHandler recipeHandler, IngredientQueryHandler ingredientQueryHandler)
        {
            _ingredientHandler = ingredientCommandHandler;
            _recipeHandler = recipeHandler;
            _ingredientQueryHandler = ingredientQueryHandler;
        }

        public void Post(CreateIngredientCommand request)
        {
            //StreamReader reader = new StreamReader(Request.InputStream);

            //var input = reader.ReadToEnd();

            // Create ingredient
            _ingredientHandler.Create(new Ingredient { Id = Guid.NewGuid(), Name = request.Name, Description = request.Description });
        }

        public void Post(CreateRecipeCommand request)
        {
            List<Step> steps = new List<Step>();
            int idx = 0;

            // Create steps
            foreach (var addRecipeStepCommand in request.Procedure)
            {
                Step step = new Step
                {
                    Description = addRecipeStepCommand.Description,
                    Order = idx++
                };

                // Get ingredients
                if (addRecipeStepCommand.Ingredients != null)
                {
                    var ingredients = _ingredientQueryHandler.FindByIds(addRecipeStepCommand.Ingredients.Select(x => x.IngredientId));

                    foreach (var addStepIngredientCommand in addRecipeStepCommand.Ingredients)
                    {
                        step.Ingredients.Add(StepIngredient.Create(ingredients.Find(x => x.Id == addStepIngredientCommand.IngredientId).Name, addStepIngredientCommand.Quantity, addStepIngredientCommand.Unit));
                    }
                }
                steps.Add(step);
            }

            // Create recipe
            _recipeHandler.Create(new Recipe
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                About = request.About,
                Procedure = steps
            });
        }

        public void Put(UpdateIngredientCommand request)
        {
            // Update ingredient
            Dictionary<string, object> values = new Dictionary<string, object>();
            if (request.Name != null)
            {
                values.Add("Name", request.Name);
            }
            if (request.Description != null)
            {
                values.Add("Description", request.Description);
            }
            _ingredientHandler.Update(request.Id, values);
        }

        public void Delete(DeleteIngredientCommand request)
        {
            // Delete ingredient
            _ingredientHandler.Delete(request.Id);
        }
    }
}
