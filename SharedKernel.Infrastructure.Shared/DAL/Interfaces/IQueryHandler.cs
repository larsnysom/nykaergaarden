using System;
using System.Collections.Generic;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces
{
    public interface IQueryHandler<TEntity>
    {
        TEntity FindById(Guid id);

        List<TEntity> FindByIds(IEnumerable<Guid> ids);
        
        List<TEntity> FindAll();
    }
}