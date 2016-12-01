using System;
using System.Collections.Generic;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.EventSource
{
    public class RootStream
    {
        public Guid Id { get; set; }

        public DateTime LastUpdateAt { get; set; }

        public int LastSnapshotAt { get; set; }

        public List<EventWrapper> Events { get; } = new List<EventWrapper>();

        public IAggregateRoot Snapshot { get; set; }
    }
}
