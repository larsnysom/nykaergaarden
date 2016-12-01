using System;
using System.Runtime.Serialization;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
