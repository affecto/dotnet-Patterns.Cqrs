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
        ICommandHandler<TCommand> Resolve<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}