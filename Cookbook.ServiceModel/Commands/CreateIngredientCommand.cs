using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.Cookbook.ServiceModel.Commands
{
    [Route("/ingredient", "POST")]
    public class CreateIngredientCommand : IReturnVoid, ISyncCommand
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
