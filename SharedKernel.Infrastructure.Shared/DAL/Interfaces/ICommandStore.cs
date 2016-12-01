using System;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces
{
    public interface ICommandStore
    {
        void PersistCommand(Guid userId, ICommand command);
    }
}