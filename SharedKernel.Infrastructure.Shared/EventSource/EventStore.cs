using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces;
using Raven.Client.Document;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.EventSource
{
    public class EventStore : IEventStore
    {
        public void PersistEvent(Guid rootId, Guid userId, IDomainEvent @event) 
        {
            using (var session = new DocumentStore().OpenSession())
            {
                var rootstream = session.Load<RootStream>(rootId);

                if (rootstream == null)
                {
                    rootstream = new RootStream { Id = rootId };
                    session.Store(rootstream);
                }
                rootstream.Events.Add(new EventWrapper(userId, @event));
                session.SaveChanges();
            }
        }

        public void PersistSnapshot(IAggregateRoot aggregate, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
