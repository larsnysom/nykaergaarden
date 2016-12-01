using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nykaergaarden.QueryModel.Recipes.Model;

namespace Nykaergaarden.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<Recipe> Recipes { get; set; }
    }
}