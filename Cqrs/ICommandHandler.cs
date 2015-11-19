namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Handler for executing commands that were sent to a bus.
    /// </summary>
    public interface ICommandHandler
    {
    }

    /// <summary>
    /// Handler for executing commands that were sent to a bus.
    /// </summary>
    /// <typeparam name="TCommand">Command type.</typeparam>
    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : class, ICommand
    {
        /// <summary>
        /// Executes a command that was sent to a bus.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        void Execute(TCommand command);
    }
}