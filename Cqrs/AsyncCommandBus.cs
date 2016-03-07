﻿using System;
using System.Threading.Tasks;

namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Provides an asynchronous bus for receiving commands. Implements a mechanism for routing commands to command handlers.
    /// </summary>
    public class AsyncCommandBus : IAsyncCommandBus
    {
        private readonly ICommandHandlerResolver commandHandlerResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBus"/> class.
        /// </summary>
        /// <param name="commandHandlerResolver">Resolver object for finding command handlers.</param>
        public AsyncCommandBus(ICommandHandlerResolver commandHandlerResolver)
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
        public virtual async Task SendAsync(Envelope<ICommand> command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            await ExecuteAsync((dynamic) command.Body);
        }

        private async Task ExecuteAsync<TCommand>(TCommand commandBody) where TCommand : class, ICommand
        {
            IAsyncCommandHandler<TCommand> handler = commandHandlerResolver.ResolveAsyncCommandHandler(commandBody);
            await handler.ExecuteAsync(commandBody);
        }
    }
}