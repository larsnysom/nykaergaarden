using System;
using System.Collections.Generic;
using System.Linq;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces;
using Raven.Client;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL
{
    public abstract class QueryHandler<TEntity> : IQueryHandler<TEntity> where TEntity : IEntity
    {
        private readonly IDocumentStore _store;

        protected IDocumentStore Store => _store;

        protected QueryHandler(IDocumentStore store)
        {
            _store = store;
        }

        public virtual TEntity FindById(Guid id)
        {
            using (var session = Store.OpenSession())
            {
                return session.Load<TEntity>(id);
            }
        }

        public virtual List<TEntity> FindByIds(IEnumerable<Guid> ids)
        {
            using (var session = _store.OpenSession())
            {
                var t = ids.Cast<ValueType>();
                return session.Load<TEntity>(t).ToList();
            }
        }

        public virtual List<TEntity> FindAll()
        {
            using (var session = Store.OpenSession())
            {
                return session.Query<TEntity>().ToList();
            }
        }
    }
}