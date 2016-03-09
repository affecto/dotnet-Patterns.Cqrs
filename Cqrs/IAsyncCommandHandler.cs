using System.Threading.Tasks;

namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Handler for asynchronously executing commands that were sent to a bus.
    /// </summary>
    /// <typeparam name="TCommand">Command type.</typeparam>
    public interface IAsyncCommandHandler<in TCommand> : ICommandHandler where TCommand : class, ICommand
    {
        /// <summary>
        /// Asynchronously executes a command that was sent to a bus.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        Task ExecuteAsync(TCommand command);
    }
}