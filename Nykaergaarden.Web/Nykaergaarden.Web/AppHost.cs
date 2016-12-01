using System;
using System.Web;
using System.Web.Mvc;
using Audit;
using ServiceStack.WebHost.Endpoints;
using Funq;
using Nykaergaarden.Cookbook.DomainModel.CRUD;
using Nykaergaarden.Cookbook.ServiceInterface;
using Nykaergaarden.QueryInterface;
using Nykaergaarden.QueryModel.Handlers;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.DAL.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.EventSource;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.RavenDb;
using Raven.Client;
using ServiceStack.Common.Web;
using ServiceStack.Mvc;
using ServiceStack.ServiceHost;

namespace Nykaergaarden.Web
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("NykaergaardenService",
            typeof(CookbookService).Assembly,
            typeof(QueryService).Assembly)
        { }

        public override void Configure(Container container)
        {
            container.RegisterAs<EventStore, IEventStore>();
            container.RegisterAs<CommandStore, ICommandStore>();

            //container.Register("EventStore", RavenSession.EventStore);
            container.Register("Model", RavenSession.Model);

            container.Register(c => new IngredientQueryHandler(c.ResolveNamed<IDocumentStore>("Model")));
            container.Register(c => new RecipeQueryHandler(c.ResolveNamed<IDocumentStore>("Model")));

            container.Register(c => new RecipeCrudHandler(c.ResolveNamed<IDocumentStore>("Model")));
            container.Register(c => new IngredientCrudHandler(c.ResolveNamed<IDocumentStore>("Model")));

            SetConfig(new EndpointHostConfig
            {
                ServiceStackHandlerFactoryPath = "api",
                DefaultContentType = ContentType.Json,
                EnableFeatures = Feature.All,
            });

            // enable audit
            var logger = Logger.Start("Nykaergaarden.Web");
            
            PreRequestFilters.Add((request, response) =>
            {                
                logger.LogRequest();
            });

            RequestFilters.Add((request, response, result) =>
            {
                
            });

            ResponseFilters.Add((request, response, result) =>
            {
                logger.LogResponse();
            });


            // enable MVC
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }
    }
}