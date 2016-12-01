using System;
using System.Collections.Generic;
using System.Linq;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS;

namespace Nykaergaarden.Cookbook.DomainModel.Model
{
    public sealed class Recipe : AggregateRoot
    {
        public string Title { get; set; }

        public string About { get; set; }

        public List<Step> Procedure { get; set; }
    }
}
