using Raven.Client;
using Raven.Client.Document;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.RavenDb
{
    public static class RavenSession
    {
        private static IDocumentStore _model;
        private static IDocumentStore _eventStore;

        public static IDocumentStore Model => _model ?? (_model = CreateDocumentStore("Model"));

        public static IDocumentStore EventStore => _eventStore ?? (_eventStore = CreateDocumentStore("EventStore"));

        private static IDocumentStore CreateDocumentStore(string connectionStringName)
        {
            return new DocumentStore { ConnectionStringName = connectionStringName }.Initialize();
        }

    }
}
