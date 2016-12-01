using System;
using System.Collections.Generic;
using System.Linq;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Util;
using Raven.Json.Linq;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL
{
    public abstract class CrudHandler<TEntity> : ICrudHandler where TEntity : IEntity
    {
        private readonly IDocumentStore _readModel;

        protected static string GetKey(Guid id)
        {
            return $"{GetEntityName()}/{id}";
        }

        protected static string GetEntityName()
        {
            return Inflector.Pluralize(typeof(TEntity).Name);
        }

        protected static RavenJObject GetMetaData()
        {
            return new RavenJObject { { "Raven-Entity-Name", GetEntityName() } };
        }

        protected CrudHandler(IDocumentStore model)
        {
            _readModel = model;
        }

        #region CRUD actions
        public virtual void Create(IEntity entity)
        {
            _readModel.DatabaseCommands.Put(GetKey(entity.Id), null, RavenJObject.FromObject(entity), GetMetaData());
        }

        public virtual void Update(Guid id, IDictionary<string, object> values)
        {
            _readModel.DatabaseCommands.Patch(GetKey(id), values.Select(item => new PatchRequest
            {
                Type = PatchCommandType.Set,
                Name = item.Key,
                Value = item.Value.ToString()
            }).ToArray());
        }

        public virtual void Delete(Guid id)
        {
            _readModel.DatabaseCommands.Delete(GetKey(id), null);
        }
        #endregion
    }
}
