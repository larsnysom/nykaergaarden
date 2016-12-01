using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS
{
    public class CommandHandler : IHandleCommand
    {
        public ICommandStore CommandStore { get; }

        public IEventStore EventStore { get; }

        protected CommandHandler(ICommandStore commandStore, IEventStore eventStore)
        {
            CommandStore = commandStore;
            EventStore = eventStore;
        }

        public void Handle(ICommand command)
        {
            
        }

        public void Persist(ICommand command)
        {
            CommandStore.PersistCommand(Guid.Empty, command);
        }
    }
}