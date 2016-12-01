using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.Cookbook.ServiceModel.Commands
{
    [Route("/ingredient/{id}", "DELETE")]
    public class DeleteIngredientCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}