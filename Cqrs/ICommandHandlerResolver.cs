namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Resolves the command handler instance for a command that was sent to a bus.
    /// </summary>
    public interface ICommandHandlerResolver
    {
        /// <summary>
        /// Resolves the command handler instance for a command that was sent to a bus.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command instance to resolve the handler for.</param>
        /// <returns>The command handler instance.</returns>
        ICommandHandler<TCommand> ResolveCommandHandler<TCommand>(TCommand command) where TCommand : class, ICommand;

        /// <summary>
        /// Resolves the asynchronous command handler instance for a command that was sent to a bus.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command instance to resolve the handler for.</param>
        /// <returns>The command handler instance.</returns>
        IAsyncCommandHandler<TCommand> ResolveAsyncCommandHandler<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}