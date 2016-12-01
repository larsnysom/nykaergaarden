using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces;
using Raven.Client;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.EventSource
{
    public class CommandStore : ICommandStore
    {
        private readonly IDocumentStore _store;

        public CommandStore(IDocumentStore store)
        {
            _store = store;
        }
        
        public void PersistCommand(Guid userId, ICommand command)
        {
            // TODO: Save command in eventstore
            using (var session = _store.OpenSession())
            {
                session.Store(new CommandWrapper(userId, command));
                session.SaveChanges();
            }
        }
    }
}
