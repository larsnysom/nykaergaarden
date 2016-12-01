using System.Collections.Generic;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS;

namespace Nykaergaarden.Cookbook.DomainModel.Model
{
    public class Step // ValueObject
    {
        public int Order { get; set; }
        public string Description { get; set; }
        public List<StepIngredient> Ingredients { get; set; }

        public Step()
        {
            Ingredients = new List<StepIngredient>();
        }
    }
}