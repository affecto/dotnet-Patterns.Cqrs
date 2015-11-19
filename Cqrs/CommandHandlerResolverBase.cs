using System;
using System.Collections.Generic;
using System.Linq;

namespace Affecto.Patterns.Cqrs
{
    public abstract class CommandHandlerResolverBase : ICommandHandlerResolver
    {
        /// <summary>
        /// Resolves the command handler object for a command that was sent to a bus.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command to resolve the handler for.</typeparam>
        /// <param name="command">The command instance to resolve the handler for.</param>
        /// <returns>The command handler instance.</returns>
        public virtual ICommandHandler<TCommand> Resolve<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            ICollection<ICommandHandler<TCommand>> handlers = ResolveHandlers<TCommand>();

            if (handlers.Count == 0 || handlers.Count > 1)
            {
                throw new InvalidOperationException(string.Format("No command handlers or more than one command handler found for command type '{0}'.", typeof(TCommand)));
            }

            return handlers.Single();
        }

        protected abstract ICollection<ICommandHandler<TCommand>> ResolveHandlers<TCommand>() where TCommand : class, ICommand;
    }
}