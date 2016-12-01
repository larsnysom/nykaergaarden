using System;
using System.Collections.Generic;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces
{
    public interface IAggregateRoot
    {
        Guid Id { get; set; }

        IEnumerable<IDomainEvent> Events { get; }

        void ApplyEvent(IDomainEvent @event);

        IEnumerable<IDomainEvent> GetNewEvents();
    }
}