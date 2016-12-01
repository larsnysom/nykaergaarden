using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.EventSource
{
    public class CommandWrapper
    {
        public Guid UserId { get; set; }

        public DateTime Created { get; set; }

        public ICommand Command { get; set; }

        public CommandWrapper(Guid userId, ICommand command)
        {
            UserId = userId;
            Created = DateTime.Now;
            Command = command;
        }
    }
}
