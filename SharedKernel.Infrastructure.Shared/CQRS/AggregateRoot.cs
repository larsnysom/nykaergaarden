using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces;
using Nykaergaarden.SharedKernel.Infrastructure.Shared.Exceptions;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        protected AggregateRoot()
        {
            RegisterEventHandlers();
        }

        [IgnoreDataMember]
        public IEnumerable<IDomainEvent> Events => _events;
        
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        private readonly Dictionary<Type, MethodInfo> _handlers = new Dictionary<Type, MethodInfo>();
        
        public void ApplyEvent(IDomainEvent @event)
        {
            _events.Add(@event);

            var eventType = @event.GetType();
            if (!_handlers.ContainsKey(eventType))
            {
                throw new InvalidCommandException($"{GetType().Name} cannot handle {@event.GetType().Name}");
            }
            _handlers[eventType].Invoke(this, new object[] {@event});
        }

        public IEnumerable<IDomainEvent> GetNewEvents()
        {
            return _events;            
        }

        private void RegisterEventHandlers()
        {
            const string requiredName = "OnApply";

            foreach (var handlerMethodInfo in GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (handlerMethodInfo.Name == requiredName && handlerMethodInfo.GetParameters().Length == 1)
                {
                    _handlers.Add(handlerMethodInfo.GetParameters()[0].ParameterType, handlerMethodInfo);
                }  
            }
        }
    }
}
