using System;
using System.Collections.Generic;
using Nykaergaarden.QueryModel.Recipes.Model;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL;
using Raven.Abstractions.Data;
using Raven.Abstractions.Util;
using Raven.Client;

namespace Nykaergaarden.QueryModel.Handlers
{
    public class RecipeQueryHandler : QueryHandler<Recipe>
    {
        public RecipeQueryHandler(IDocumentStore store) : base(store) { }

        public override List<Recipe> FindAll()
        {
            var result = Store.DatabaseCommands.Query("Raven/DocumentsByEntityName",
                new IndexQuery {Query = "__document_id:Recipes*"});

            return new List<Recipe>();

            throw  new NotImplementedException();
        }
    }
}