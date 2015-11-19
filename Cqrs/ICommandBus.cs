namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Represents a bus for receiving commands.
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Sends command to the bus for execution.
        /// </summary>
        /// <param name="command">Command wrapped in an envelope.</param>
        void Send(Envelope<ICommand> command);
    }
}