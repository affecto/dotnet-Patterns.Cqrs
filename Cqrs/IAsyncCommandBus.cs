using System.Threading.Tasks;

namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Represents an asynchronous bus for receiving commands.
    /// </summary>
    public interface IAsyncCommandBus
    {
        /// <summary>
        /// Sends command to the bus for execution.
        /// </summary>
        /// <param name="command">Command wrapped in an envelope.</param>
        /// <typeparam name="TCommand">Command type.</typeparam>
        Task SendAsync<TCommand>(Envelope<TCommand> command) where TCommand : class;
    }
}