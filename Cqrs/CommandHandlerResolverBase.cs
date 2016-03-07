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
        public virtual ICommandHandler<TCommand> ResolveCommandHandler<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            ICollection<ICommandHandler<TCommand>> handlers = ResolveCommandHandlers<TCommand>();

            if (handlers.Count == 0 || handlers.Count > 1)
            {
                throw new InvalidOperationException(string.Format("No command handlers or more than one command handler found for command type '{0}'.", typeof(TCommand)));
            }

            return handlers.Single();
        }

        /// <summary>
        /// Resolves the asynchronous command handler instance for a command that was sent to a bus.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command instance to resolve the handler for.</param>
        /// <returns>The command handler instance.</returns>
        public IAsyncCommandHandler<TCommand> ResolveAsyncCommandHandler<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            ICollection<IAsyncCommandHandler<TCommand>> handlers = ResolveAsyncCommandHandlers<TCommand>();

            if (handlers.Count == 0 || handlers.Count > 1)
            {
                throw new InvalidOperationException(string.Format("No asynchronous command handlers or more than one asynchronous command handler found for command type '{0}'.", typeof(TCommand)));
            }

            return handlers.Single();
        }

        protected abstract ICollection<ICommandHandler<TCommand>> ResolveCommandHandlers<TCommand>() where TCommand : class, ICommand;
        protected abstract ICollection<IAsyncCommandHandler<TCommand>> ResolveAsyncCommandHandlers<TCommand>() where TCommand : class, ICommand;
    }
}