using System;
using System.Collections.Generic;
using System.Linq;

namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Resolves the command handler instance for a command that was sent to a bus.
    /// </summary>
    public class CommandHandlerResolver : CommandHandlerResolverBase
    {
        protected readonly IEnumerable<ICommandHandler> commandHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerResolver"/> class.
        /// </summary>
        /// <param name="commandHandlers">A collection of registered command handlers.</param>
        public CommandHandlerResolver(IEnumerable<ICommandHandler> commandHandlers)
        {
            if (commandHandlers == null)
            {
                throw new ArgumentNullException("commandHandlers");
            }

            this.commandHandlers = commandHandlers;
        }

        protected override ICollection<TCommandHandler> ResolveCommandHandlers<TCommandHandler>()
        {
            return commandHandlers.OfType<TCommandHandler>().ToList();
        }
    }
}