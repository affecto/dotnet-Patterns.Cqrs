using System;

namespace Affecto.Patterns.Cqrs
{
    /// <summary>
    /// Static factory class for <see cref="Envelope{T}"/>.
    /// </summary>
    public abstract class Envelope
    {
        /// <summary>
        /// Creates an envelope for the given body.
        /// </summary>
        /// <param name="body">Command body.</param>
        /// <param name="correlationId">Correlation id for tracking the command execution.</param>
        public static Envelope<ICommand> Create<TCommand>(TCommand body, string correlationId = null) where TCommand : class, ICommand
        {
            return new Envelope<ICommand>(body, correlationId);
        }
    }

    /// <summary>
    /// Provides the envelope for a command that will be sent to a bus.
    /// </summary>
    public class Envelope<TCommand> : Envelope where TCommand : class, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{T}"/> class.
        /// </summary>
        /// <param name="body">Command body.</param>
        /// <param name="correlationId">Correlation id for tracking the command execution.</param>
        public Envelope(TCommand body, string correlationId = null)
        {
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            Body = body;
            CorrelationId = correlationId;
        }

        /// <summary>
        /// Gets the command body.
        /// </summary>
        public TCommand Body { get; private set; }

        /// <summary>
        /// Gets the correlation id.
        /// </summary>
        public string CorrelationId { get; private set; }
    }
}