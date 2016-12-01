using System;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}