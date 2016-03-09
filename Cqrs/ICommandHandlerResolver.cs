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
        /// <typeparam name="TCommandHandler">The type of the command handler.</typeparam>
        /// <returns>The command handler instance.</returns>
        TCommandHandler ResolveCommandHandler<TCommandHandler>() where TCommandHandler : class, ICommandHandler;
    }
}