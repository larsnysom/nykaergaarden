using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.Cookbook.ServiceModel.Commands
{
    [Route("/ingredient/{id}", "PUT")]
    public class UpdateIngredientCommand : IReturnVoid, ICommand
    {
        public Guid Id { get; set; }

        public string Name{ get; set; }

        public string Description { get; set; }
    }
}
