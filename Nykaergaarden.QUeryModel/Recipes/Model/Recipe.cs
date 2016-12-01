using System;
using System.Collections.Generic;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.QueryModel.Recipes.Model
{
    public class Recipe : IEntity
    {
        public Guid Id { get; }

        public string Title { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<string> Procedure { get; set; }
    }
}