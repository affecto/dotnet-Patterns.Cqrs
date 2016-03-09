using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace Affecto.Patterns.Cqrs.Autofac
{
    /// <summary>
    /// Resolves the command handler instance for a command from Autofac component context.
    /// </summary>
    public class ContainerCommandHandlerResolver : CommandHandlerResolverBase
    {
        private readonly IComponentContext componentContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerCommandHandlerResolver"/> class.
        /// </summary>
        /// <param name="componentContext">Autofac component context.</param>
        public ContainerCommandHandlerResolver(IComponentContext componentContext)
        {
            if (componentContext == null)
            {
                throw new ArgumentNullException("componentContext");
            }

            this.componentContext = componentContext;
        }

        protected override ICollection<TCommandHandler> ResolveCommandHandlers<TCommandHandler>()
        {
            return componentContext.Resolve<IEnumerable<TCommandHandler>>().ToList();
        }
    }
}