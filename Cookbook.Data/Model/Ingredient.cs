using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS;

namespace Nykaergaarden.Cookbook.DomainModel.Model
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
