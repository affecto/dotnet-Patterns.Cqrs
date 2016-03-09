using System;
using System.Collections.Generic;
using System.Linq;

namespace Affecto.Patterns.Cqrs
{
    public abstract class CommandHandlerResolverBase : ICommandHandlerResolver
    {
        /// <summary>
        /// Resolves the command handler instance for a command that was sent to a bus.
        /// </summary>
        /// <typeparam name="TCommandHandler">The type of the command handler.</typeparam>
        /// <returns>The command handler instance.</returns>
        public TCommandHandler ResolveCommandHandler<TCommandHandler>() where TCommandHandler : class, ICommandHandler
        {
            ICollection<TCommandHandler> handlers = ResolveCommandHandlers<TCommandHandler>();

            if (handlers.Count == 0 || handlers.Count > 1)
            {
                throw new InvalidOperationException(string.Format("No command handlers or more than one command handler found with type '{0}'.", typeof(TCommandHandler)));
            }

            return handlers.Single();
        }

        protected abstract ICollection<TCommandHandler> ResolveCommandHandlers<TCommandHandler>()
            where TCommandHandler : class, ICommandHandler;
    }
}