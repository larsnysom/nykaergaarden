using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces
{
    public interface IEventStore
    {
        void PersistEvent(Guid rootId, Guid userId, IDomainEvent @event);
        void PersistSnapshot(IAggregateRoot aggregate, Guid userId);
    }
}