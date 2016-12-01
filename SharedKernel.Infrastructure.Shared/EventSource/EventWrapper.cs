using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.EventSource
{
    public class EventWrapper
    {
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public IDomainEvent Event { get; set; }

        public EventWrapper(Guid userId, IDomainEvent @event)
        {
            UserId = userId;
            Created = DateTime.Now;
            Event = @event;
        }
    }
}
