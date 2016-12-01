using System;
using System.Collections.Generic;
using Nykaergaarden.Cookbook.DomainModel.Enums;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.Cookbook.ServiceModel.Commands
{
    [Route("/recipe", "POST")]
    public class CreateRecipeCommand : IReturnVoid, ISyncCommand
    {
        public string Title { get; set; }

        public string About { get; set; }
        
        public AddRecipeStepCommand[] Procedure { get; set; }
    }

    public class AddRecipeStepCommand
    {
        public string Description { get; set; }

        public AddStepIngredientCommand[] Ingredients { get; set; }
    }

    public class AddStepIngredientCommand
    {
        public Guid IngredientId { get; set; }

        public decimal Quantity { get; set; }

        public MeasureUnit Unit { get; set; }
        
    }
}