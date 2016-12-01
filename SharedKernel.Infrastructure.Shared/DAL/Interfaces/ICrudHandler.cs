using System;
using System.Collections.Generic;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces
{
    public interface ICrudHandler
    {
        void Create(IEntity entity);

        void Update(Guid id, IDictionary<string, object> values);

        void Delete(Guid id);
    }
}