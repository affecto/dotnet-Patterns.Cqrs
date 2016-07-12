using System;

namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Provides a bus for receiving commands. Implements a mechanism for routing commands to command handlers.
    /// </summary>
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerResolver commandHandlerResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBus"/> class.
        /// </summary>
        /// <param name="commandHandlerResolver">Resolver object for finding command handlers.</param>
        public CommandBus(ICommandHandlerResolver commandHandlerResolver)
        {
            if (commandHandlerResolver == null)
            {
                throw new ArgumentNullException("commandHandlerResolver");
            }

            this.commandHandlerResolver = commandHandlerResolver;
        }

        /// <summary>
        /// Sends command to the bus for execution.
        /// </summary>
        /// <param name="command">Command wrapped in an envelope.</param>
        /// /// <typeparam name="TCommand">Command type.</typeparam>
        public virtual void Send<TCommand>(Envelope<TCommand> command) where TCommand : class
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            Execute((dynamic) command.Body);
        }

        private void Execute<TCommand>(TCommand commandBody) where TCommand : class
        {
            ICommandHandler<TCommand> handler = commandHandlerResolver.ResolveCommandHandler<ICommandHandler<TCommand>>();
            handler.Execute(commandBody);
        }
    }
}